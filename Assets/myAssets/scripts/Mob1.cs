using  UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class mobAtributes
{
		public float HP;
		public int Dmg;
		public float maxSped = 10f;
		public float moveForce = 5;
		public int blunt, point, slash;
		public int jump = 100;
		public bool moving = false;
		public int optTargetRange = 30;
		public float  flyAmount = 0.5f;

	
	
	
	
	
}

public class Mob1 : Entity
{
		public mobAtributes thisAttributes = new mobAtributes ();

		//---------------------------------------
		protected bool landed = false;
		public bool grounded = false;
		protected bool turnR = false;
		protected bool front = true;

		//---------------------------------------
		public Transform[] groundCheck;
		public Vector2 centerOfMass;
		public LayerMask whatGround;
		public Animator thisAnim;
		public BodyPart[] bodyParts;
		public Transform frontBody;
		public Transform sideBody;
		public bool animated = false;
		public bool detectedFacing = false;
		public AudioSource thisAudio;
		public AudioClip  jumpClip;
		public AudioClip  stepClip;
		public AudioClip  landClip;
		public AudioClip  movingClip;



		void Start ()
		{
				
				thisManage = gameManager.thisM;
				checkNecesseries ();
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
			
		}

		protected virtual void checkNecesseries ()
		{

				if (thisLevel == null)
						Debug.LogError ("no Level referenced for this entity: " + gameObject.name);
				if (thisAnim == null && animated) {
						Debug.LogError ("no animator is provided");
				}
				if (groundCheck == null)
						Debug.Log ("no feets included");
				bodyParts = GetComponentsInChildren<BodyPart> ();
				foreach (BodyPart b in bodyParts) {
						b.thisLevel = thisLevel;
				}

		}
		
		void Update ()
		{
				if (animated)
						updateAnim ();
				checkDead ();
				checkFacing ();
		}

		protected void checkDead ()
		{
				if (thisAttributes.HP <= 0)
						DestroyEntity (0);
				if (transform.position.y < thisLevel.deathHeight)
						thisAttributes.HP = 0;
		}

		protected void checkFacing ()
		{
				if (detectedFacing) {
						if (thisAttributes.moving) {
								front = false;
								frontBody.gameObject.SetActive (false);
								sideBody.gameObject.SetActive (true);
						} else {
								front = true;

								sideBody.gameObject.SetActive (false);
								frontBody.gameObject.SetActive (true);
						}

				}
		}
		
		public virtual void stepSound ()
		{
		
				thisAudio.PlayOneShot (stepClip);

		}

		public virtual void playJumpSound ()
		{
		
				thisAudio.PlayOneShot (jumpClip);
		
		}
		public virtual void playLandSound ()
		{
		
				thisAudio.PlayOneShot (landClip);
		
		}
		public virtual void playMoveSound ()
		{
		
				thisAudio.PlayOneShot (movingClip, 0.5f);
		
		}


		protected virtual void checkground ()
		{
				int yGround = 0;
				int nGround = 0;
				foreach (Transform t in groundCheck) {
						if (Physics2D.Linecast (transform.position, t.position, whatGround))
								yGround++;
						else
								nGround ++;
				}
				bool ground;
				Debug.Log (nGround + " " + yGround);
				if (yGround > nGround)
						ground = true;
				else
						ground = false;
		
				if (!grounded && ground) {
						landed = true;
						grounded = true;
			
						playLandSound ();
			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
				}
		}
		void FixedUpdate ()
		{
				checkground ();
				/*if (move < 0 && turnR) {
			flip ();
		} else if (move > 0 && !turnR) {
			flip ();
		}
				if (rigidbody2D.velocity.x < thisAttributes.maxSped)
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + (move * moveForce), rigidbody2D.velocity.y);
				*/
		}

		public virtual void updateAnim ()
		{
				thisAnim.SetBool ("grounded", grounded);
				thisAnim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				thisAnim.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));
				if (grounded && Mathf.Abs (rigidbody2D.velocity.x) > 0.1)
						thisAttributes.moving = true;
				else
						thisAttributes.moving = false;


		}

		public virtual void takeDmg (int damage)
		{
				thisAttributes.HP -= damage;
		}
		
		public virtual void flip ()
		{
				turnR = !turnR;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
		}
		
		public virtual void moveX (float moveX)
		{
				float xMove = (moveX * thisAttributes.moveForce);

	
				if (!grounded) {
						xMove /= thisAttributes.flyAmount;
				}

				if (Mathf.Abs (rigidbody2D.velocity.x) < thisAttributes.maxSped)
						rigidbody2D.velocity = new Vector2 (xMove + rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		
		}
			
		public virtual void jump (int jumpF)
		{

				if (grounded) {
						rigidbody2D.AddForce (new Vector2 (0, jumpF));
						playJumpSound ();

				} 

		}

		void OnTriggerEnter2D (Collider2D other)
		{

				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = other.GetComponent<Teleport> ();
						teleSpot.teleport (gameObject);
						
				}
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
						if (thisBoost == null)
								Debug.LogError ("no collision boost script attached");
						/*	float thisX = rigidbody2D.velocity.x / 2;
			float thisY = rigidbody2D.velocity.y / 2;
			
			Vector2 force = new Vector2 (thisX +((thisBoost.multiX) * thisBoost.boostAmount)
			                             , thisY + ((-thisBoost.multiY) * thisBoost.boostAmount));
			rigidbody2D.AddForceAtPosition (force, transform.position);

*/
						thisBoost.boost (rigidbody2D);
				}
		
				
				if (other.gameObject.tag == "Cannon") {
						cannon thisCannon = other.gameObject.GetComponent<cannon> ();
						if (thisCannon == null)
								Debug.LogError ("no cannon script attached");
						thisCannon.shoot ();
			
			
				}

				if (other.gameObject.tag == "NPC") {
						NPC thisCannon = other.gameObject.GetComponent<NPC> ();
						if (thisCannon == null)
								Debug.LogError ("no NPC script attached but tag is NPC");
						thisCannon.PlayerInteract ();
			
				}
		
		
		}
	
		void OnCollisionEnter2D (Collision2D other)
		{

				
				if (other.gameObject.tag == "Destroyable") {
						Resource temp = other.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf (Random.Range (0, 5));
				}

				if (other.gameObject.tag == "Enemy") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, (transform.position.y - other.transform.position.y) * Random.Range (0, 5));
						rigidbody2D.AddForce (force * Random.Range (0, 50));
						takeDmg (1);
		
				}

				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, Random.Range (0, 5));
						rigidbody2D.AddForce (force * Random.Range (0, 50));
						takeDmg (1);

				}

				


		}
	


}
