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
		public int optTargetRange = 30;
		public bool canFly = false;

	
	
	
	
	
}

public class Mob1 : Entity
{
		public mobAtributes thisAttributes = new mobAtributes ();

		//---------------------------------------
		protected bool landed = false;
		public bool grounded = false;
		protected bool turnR = false;
		//---------------------------------------
		public float groundRad = 0.16f;
		public Transform[] groundCheck;
		public Vector2 centerOfMass;
		public LayerMask whatGround;
		public Animator thisAnim;

		void Start ()
		{
				
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				if (thisAnim == null) {
						thisAnim = GetComponent<Animator> ();
				}
				if (thisAnim == null) {
						Debug.LogError ("no animator is provided");
				}
				if (groundCheck == null)
						Debug.Log ("no feets included");
		}
		
		void Update ()
		{

				if (thisAttributes.HP < 0)
						DestroyEntity (0);
				if (transform.position.y < thisLevel.deathHeight)
						thisAttributes.HP = 0;
				updateAnim ();

		}
		
		void FixedUpdate ()
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
					
			
			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
				}
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



		}

		public virtual void takeDmg (int damage, string type)
		{
				if (type == "blunt") {
						thisAttributes.HP -= (damage - thisAttributes.blunt);

				} else if (type == "point") {
						thisAttributes.HP -= (damage - thisAttributes.point) / 2;
			
				} else if (type == "slash") {
						int preDmg = 0;
						preDmg = (Random.Range (0, damage) / (thisAttributes.slash * Random.Range (-2, thisAttributes.slash)));
						thisAttributes.HP -= (preDmg + Random.Range (-thisAttributes.slash, thisAttributes.slash));
			
				}


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
				if (grounded) {
						if (Mathf.Abs (rigidbody2D.velocity.x) < thisAttributes.maxSped)
								rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + 
										(moveX * thisAttributes.moveForce), rigidbody2D.velocity.y);
				}
		}
			
		public virtual void jump (int jumpF)
		{

				if (grounded) {
						rigidbody2D.AddForce (new Vector2 (0, jumpF));
					

				} 

		}

		void OnTriggerEnter2D (Collider2D other)
		{

				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = (Teleport)other.GetComponent ("Teleport");
						Vector3 teleTo = teleSpot.teleto.transform.position;
						this.transform.position = new Vector3 (teleTo.x - teleSpot.xOff,
			                                       teleTo.y - teleSpot.yOff, teleTo.z - teleSpot.zOff);
						
				}
		
				
			
				
		
		}

		void OnCollisionEnter2D (Collision2D other)
		{

				
				if (other.gameObject.tag == "Destroyable") {
						Resource temp = other.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf (Random.Range (0, 5));
				}

				if (other.gameObject.tag == "Enemy") {
						rigidbody2D.AddForce (new Vector2 (other.rigidbody.velocity.x + Random.Range (0, 300) * 100
								, Random.Range (0, 90) * 100));
				}

				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
						Vector2 force = new Vector2 (rigidbody2D.velocity.x * (-1 * thisBoost.boostAmount)
			                             , rigidbody2D.velocity.y * (-20 * thisBoost.boostAmount));
						rigidbody2D.AddForce (force);
				}


		}
	


}
