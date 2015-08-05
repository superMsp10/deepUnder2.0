using UnityEngine;
using System.Collections;

public class energyball : Arrow
{

		public LayerMask gravityEffect;
		public int distance;
		public int force = 1000;
		public int explodeDistance;
		public int explodeForce = 1000;
		public Animation thisAnim;
		public AnimationClip bootUp;
		public ParticleSystem bootUpParticle;
		public ParticleSystem standByParticle;
		public ParticleSystem explodeParticle;
		public Transform resetPos;


		void OnCollisionEnter2D (Collision2D coll)
		{
		
	
				Mob1 mab = coll.gameObject.GetComponent<Mob1> ();
				if (coll.gameObject != controller && mab != null) {
			
						mab.takeDmg (damage);
				}

				if (coll.gameObject.tag == "Untagged") {
			
						explodeEnergyBall ();
				}
		
		}



		void FixedUpdate ()
		{

				Collider2D[] hit = Physics2D.OverlapCircleAll (transform.position, distance,
		                                               gravityEffect);

				foreach (Collider2D c in hit) {
						Rigidbody2D r = c.rigidbody2D;
						if (r != null) {
								r.AddForce ((transform.position - c.transform.position) * (force / Vector2.Distance (transform.position, c.transform.position)));
						}
				}
	
		}




		public void explodeEnergyBall ()
		{
				standByParticle.Stop ();
				explodeParticle.Play ();
				GetComponent<SpriteRenderer> ().enabled = false;

				Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, explodeDistance);
		
				// For each collider...
				foreach (Collider2D en in enemies) {
						// Check if it has a rigidbody (since there is only one per enemy, on the parent).
						if (en.gameObject.GetInstanceID () != gameObject.GetInstanceID ()) {
				
				
								Rigidbody2D rb = en.rigidbody2D;
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
												Debug.Log (damage * distanceForce);
										}
								}
				
						}	
						Invoke ("reset", 2f);
			
			
				}
		}

		void reset ()
		{
				transform.position = resetPos.position;
				rigidbody2D.isKinematic = true;
				gameObject.SetActive (false);
				GetComponent<SpriteRenderer> ().enabled = true;
				controller.GetComponent<groth> ().charging = false;

				enabled = false;
		}


}
