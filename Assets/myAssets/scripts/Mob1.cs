using  UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class mobAtributes
{
		public float HP;
		public float maxHP;

		public int Dmg;
		public float maxSped = 10f;
		public float moveForce = 5;
		public int jump = 100;
		public bool moving = false;
		public bool teleports = true;
		public int optTargetRange = 30;
		public float  flyAmount = 0.5f;

	
	
	
	
	
}

public class Mob1 : Entity
{
		public mobAtributes thisAttributes = new mobAtributes ();

		//---------------------------------------
		protected bool landed = false;
		public bool grounded = false;

		public bool turnR = false;
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
		public AudioClip  dmgClip;
		public AudioClip  movingClip;
		public Slider healthbar;
		public bool falling;
		public GameObject weaponHand;
		public bool attacking;
		public GameObject attackArea;





		void Start ()
		{
				
				thisManage = gameManager.thisM;
				checkNecesseries ();
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				thisAudio = AudioManager.thisAM.playerFX;

		}

		public override void changeLevel (level lev)
		{
				if (lev == null)
						Debug.LogError ("transfering level is null: " + gameObject.name);
				thisLevel.removeEntity (this);
				thisLevel = lev;
				thisLevel.addEntity (this);
				checkNecesseries ();



		}

		protected virtual void checkNecesseries ()
		{

				bodyParts = GetComponentsInChildren<BodyPart> ();
				if (thisLevel == null) {
						Debug.LogError ("no Level referenced for this entity: " + gameObject.name);
				} else {
						foreach (BodyPart b in bodyParts) {
								b.thisLevel = thisLevel;
						}

				}
				if (thisAnim == null && animated) {
						Debug.LogError ("no animator is provided");
				}
				if (groundCheck == null)
						Debug.Log ("no feets included");
				
				if (healthbar != null) {
						healthbar.maxValue = thisAttributes.maxHP;
						healthbar.value = thisAttributes.HP;
				} else {

						Debug.Log ("no health bar provided");
				}
		}
		
		void Update ()
		{
				if (animated)
						updateAnim ();
				checkDead ();
				checkFacing ();
		}

		protected virtual void checkDead ()
		{
				if (thisAttributes.HP <= 0)
						die ();
				if (transform.position.y < thisLevel.deathHeight)
						thisAttributes.HP = 0;
		}

		protected void checkFacing ()
		{

				if (Mathf.Abs (rigidbody2D.velocity.x) > 1) {
						thisAttributes.moving = true;
			
				} else if (attacking) {
						thisAttributes.moving = true;
				} else {
						thisAttributes.moving = false;
			
				}
				if (detectedFacing) {
						if (thisAttributes.moving || attacking) {
								front = false;
								frontBody.gameObject.SetActive (false);
								sideBody.gameObject.SetActive (true);
						} else {
								front = true;

								sideBody.gameObject.SetActive (false);
								frontBody.gameObject.SetActive (true);
						}
						if (rigidbody2D.velocity.y < -20 && !attacking) {
				
								falling = true;
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
				if (thisAudio == null) {
			
						thisAudio = AudioManager.thisAM.playerFX;
				}
				thisAudio.PlayOneShot (jumpClip);
		
		}
		public virtual void playLandSound ()
		{
				if (thisAudio == null) {
			
						thisAudio = AudioManager.thisAM.playerFX;
				}
				thisAudio.PlayOneShot (landClip);
		
		}
		public virtual void playMoveSound ()
		{
		
				thisAudio.PlayOneShot (movingClip, 0.5f);
		
		}

		public virtual void die ()
		{

				Destroy (gameObject);

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
				if (yGround > nGround)
						ground = true;
				else
						ground = false;
		
				if (!grounded && ground) {
						landed = true;
						grounded = true;
						falling = false;
			
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
				thisAnim.SetBool ("Attack", attacking);
				thisAnim.SetBool ("moving", thisAttributes.moving);


		}

		public virtual void takeDmg (float damage)
		{
				thisAttributes.HP -= damage;
				if (thisAudio == null) {
			
						thisAudio = AudioManager.thisAM.playerFX;
				}
				thisAudio.PlayOneShot (dmgClip);
				healthbar.value = thisAttributes.HP;
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


				if (thisAttributes.teleports) {
						if (other.gameObject.tag == "teleport") {
								Teleport teleSpot = other.GetComponent<Teleport> ();
								teleSpot.teleport (gameObject);
						
						}
						if (other.gameObject.tag == "boost") {
								collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
								if (thisBoost == null)
										Debug.LogError ("no collision boost script attached");
				
								thisBoost.boost (rigidbody2D);
						}
		
				
			
				}
		
		
		}
	
		void OnCollisionEnter2D (Collision2D other)
		{

				
				if (other.gameObject.tag == "Destroyable") {
						Resource temp = other.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf ();
				}

				if (other.gameObject.tag == "Enemy") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
		
				}

				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);

				}

				if (other.gameObject.tag == "NPC") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}

				


		}
	
		

}
