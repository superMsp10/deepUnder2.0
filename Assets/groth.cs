﻿using UnityEngine;
using System.Collections;

public class groth : Dummy
{
		public GameObject energyBall;
		public energyball energyBallScript;
		public bool charging = false;


		
		public void throwEnergyBall ()
		{
		
				energyBall.rigidbody2D.isKinematic = false;
				energyBallScript.standByParticle.Play ();
				energyBallScript.enabled = true;
				Vector2 dir;
				if (target != null)
						dir = target.transform.position - transform.position;
				else {
						dir = transform.position;
				}
				energyBall.rigidbody2D.AddForce (dir * 15000);

		}

		public void prepareEnergyBall ()
		{
		
				chargeEnergyBall ();
				Invoke ("throwEnergyBall", 10f);		
		}


	
		public void chargeEnergyBall ()
		{

				energyBall.transform.position = energyBallScript.resetPos.position;

				charging = true;
				energyBallScript.enabled = false;
				energyBall.SetActive (true);
				energyBall.rigidbody2D.isKinematic = true;
				energyBallScript.bootUpParticle.Play ();

		}

		void FixedUpdate ()
		{
		
		
				checkground ();
				if (!charging)
						TargetSight ();
		
		}


		protected override void TargetSight ()
		{
		
		
				if (target != null) {
						if (Vector2.Distance (target.transform.position, transform.position)
								> thisAttributes.optTargetRange) {
								moveAi ();
						} else {
								checkLooking ();
						}
			
						if (Vector2.Distance (target.transform.position, transform.position) > sight) {
								target = null;
								if (despawnWithDistance) {
										gameObject.SetActive (false);
								}
				
				
						}
				} else {
						selectTarget ();
						attacking = false;
						thisAttributes.moving = false;
				}
		
		}
		public override void moveAi ()
		{
		
		
				Vector2 targetPos = thisManage.transform.TransformPoint (target.transform.position);
				Vector2 thisPos = thisManage.transform.TransformPoint (transform.position);
			
		
				float move = 0;
		
				if (targetPos.x < thisPos.x) {
						move = (Vector2.right.x * -1);
			
				} else if (targetPos.x > thisPos.x) {
						move = (Vector2.right.x);
			
				}
		
				moveX (move);
		
		
		
		
				jump (thisAttributes.jump);
		
		
		
		
		}


		void OnCollisionEnter2D (Collision2D other)
		{

		
				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (1000, 10000));
						takeDmg (thisAttributes.Dmg);
			
				}
		

		
		
		
		
		}

		

}
