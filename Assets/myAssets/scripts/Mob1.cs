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
		public int jumpLimit = 10;
		public int jumped = 0;
		public int optTargetRange = 30;
		public bool canFly = false;

	
	
	
	
	
}

public class Mob1 : Entity
{
		public mobAtributes thisAttributes = new mobAtributes ();

		//---------------------------------------
		protected bool landed = false;
		protected bool grounded = false;
		protected bool turnR = false;
		//---------------------------------------
		public float groundRad = 0.16f;
		public Transform groundCheck;
		public Vector2 centerOfMass;
		public LayerMask whatGround;

		void Start ()
		{
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;



		}
		
		void Update ()
		{

				if (thisAttributes.HP < 0)
						DestroyEntity (0);

		}
		
		void FixedUpdate ()
		{
		
				bool ground = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatGround);

				if (!grounded && ground) {
						landed = true;
						thisAttributes.jumped = 0;
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
	
		public void takeDmg (int damage, string type)
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
		
		public void flip ()
		{
				turnR = !turnR;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
		}
		
		public void moveX (float moveX)
		{
		
				if (Mathf.Abs (rigidbody2D.velocity.x) < thisAttributes.maxSped)
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + 
								(moveX * thisAttributes.moveForce), rigidbody2D.velocity.y);

		}
			
		public void jump (int jumpF)
		{
				if (thisAttributes.jumped < thisAttributes.jumpLimit) {
						rigidbody2D.AddForce (new Vector2 (0, jumpF));
						thisAttributes.jumped++;
				} else {


				}


		}
	


}
