﻿using UnityEngine;
using System.Collections;

public class energyball : Arrow
{

		public LayerMask gravityEffect;
		public int distance;
		public int force = 1000;
		public int explodeDistance;
		public int explodeForce = 1000;
		public int timeTillExplosion;
		public ParticleSystem bootUpParticle;
		public ParticleSystem standByParticle;
		public ParticleSystem explodeParticle;
		public Transform resetPos;
		public GameObject image;
		public bool exploding = false;


		void OnCollisionEnter2D (Collision2D coll)
		{
		
	
				Mob1 mab = coll.gameObject.GetComponent<Mob1> ();
				if (mab != null && mab.gameObject.layer != gameObject.layer) {
						controller.GetComponent<groth> ().takeDmg (-100);

						explodeEnergyBall ();
				}


		
		}



		void FixedUpdate ()
		{
				timeTillExplosion--;

				if (timeTillExplosion < 0)
						explodeEnergyBall ();

				Collider2D[] hit = Physics2D.OverlapCircleAll (transform.position, distance,
		                                               gravityEffect);

				foreach (Collider2D c in hit) {
						Rigidbody2D r = c.GetComponent<Rigidbody2D>();
						if (r != null && r != GetComponent<Rigidbody2D>()) {
								r.AddForce ((transform.position - c.transform.position) * (force / Vector2.Distance (transform.position, c.transform.position)));
						}
				}
	
		}




		public void explodeEnergyBall ()
		{
				if (!exploding) {
						exploding = true;
						standByParticle.Stop ();
						explodeParticle.Play ();
						image.GetComponent<SpriteRenderer> ().enabled = false;

						Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, explodeDistance);
		
						// For each collider...
						foreach (Collider2D en in enemies) {
								// Check if it has a rigidbody (since there is only one per enemy, on the parent).
								if (en.gameObject.GetInstanceID () != gameObject.GetInstanceID ()) {
				
				
										Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
										Mob1 mab = en.GetComponent<Mob1> ();
										if (rb != null) {
												// Find the Enemy script and set the enemy's health to zero.
					
												float distanceForce;
												// Find a vector from the bomb to the enemy.
												Vector3 deltaPos = rb.transform.position - transform.position;
												if (Vector2.Distance (rb.transform.position, transform.position) < explodeDistance) {
														distanceForce = explodeDistance - Vector2.Distance (rb.transform.position, transform.position);
												} else {
														distanceForce = 0f;
												}
												// Apply a force in this direction with a magnitude of bombForce.
												Vector3 force2 = deltaPos.normalized * explodeForce * distanceForce;
												rb.AddForce (force2, ForceMode2D.Impulse);
												if (mab != null) {
														mab.takeDmg (damage * distanceForce);
												}
										}
				
								}	
								Invoke ("reset", 1f);
			
			
						}
				}
		}

		void reset ()
		{
				exploding = false;
				transform.position = resetPos.position;
				GetComponent<Rigidbody2D>().isKinematic = true;
				gameObject.SetActive (false);
				timeTillExplosion = 300;
				image.GetComponent<SpriteRenderer> ().enabled = true;
				controller.GetComponent<groth> ().charging = false;

				Invoke ("resetCharged", 10f);

				enabled = false;
		}

		public void resetCharged ()
		{
				controller.GetComponent<groth> ().recharged = true;
		}


}
