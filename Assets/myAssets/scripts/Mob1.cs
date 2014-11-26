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



}

public class Mob1 : Entity
{
		public mobAtributes thisDmgDetails = new mobAtributes ();

		//---------------------------------------
		protected bool landed = false;
		protected bool grounded = false;
		bool turnR = false;
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
		
		void FixedUpdate ()
		{
		
				bool ground = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatGround);
				if (!grounded && ground) {
						landed = true;
						grounded = true;
			
			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
			


				}
		}

		public void takeDmg (int damage, string type)
		{
				if (type == "blunt") {
			thisDmgDetails.HP -= (damage - thisDmgDetails.blunt);

				} else if (type == "point") {
			thisDmgDetails.HP -= (damage - thisDmgDetails.point) / 2;
			
				} else if (type == "slash") {
						int preDmg = 0;
			preDmg = (Random.Range (0, damage) / (thisDmgDetails.slash * Random.Range (-2, thisDmgDetails.slash)));
			thisDmgDetails.HP -= (preDmg + Random.Range (-thisDmgDetails.slash, thisDmgDetails.slash));
			
				}


		}
		
		void flip ()
		{
				turnR = !turnR;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
		}

}
