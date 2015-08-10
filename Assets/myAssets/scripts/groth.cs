using UnityEngine;
using System.Collections;

public class groth : Dummy
{
		public GameObject energyBall;
		public energyball energyBallScript;
		public bool charging = false;
		bool punded = false;
		bool particleInPos = false;

		public ParticleSystem poundParticles;


		
		public void throwEnergyBall ()
		{
				takeDmg (100.0f);
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
				float xDiff = targetPos.x - thisPos.x;
		
				if (xDiff < 0) {
						move = (Vector2.right.x * -1);
			
				} else if (xDiff > 0) {
						move = (Vector2.right.x);
			
				}

			
				float yDiff = targetPos.y - thisPos.y;
				if (yDiff > 0) {
						//if (!charging)
						//	prepareEnergyBall ();
				} else if (!punded && yDiff < 0 && Mathf.Abs (xDiff) < 10) {
						groundPound ();
				}
		
				moveX (move);
		
		
		
		
				jump (thisAttributes.jump);
		
		
		
		
		}

		public void groundPound ()
		{
				rigidbody2D.AddForce (new Vector2 (0, -100000));
			
				poundParticles.Play ();
				foreach (Transform t in groundCheck) {
						
						if (Physics2D.OverlapCircleAll (t.position, 0.5f, whatEnemy) != null) {
								if (!particleInPos) {
										poundParticles.transform.position = t.position;
										particleInPos = true;
								}
								target.GetComponent<Mob1> ().takeDmg (20);
								Debug.Log ("hello");

						}
				}
				punded = true;
				Invoke ("resetPounded", 5f);

		}


		void OnCollisionEnter2D (Collision2D other)
		{

		
				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (1000, 10000));
						takeDmg (thisAttributes.Dmg);
			
				}
		

		
		
		
		
		}

		void resetPounded ()
		{
				poundParticles.Stop ();
				punded = false;
				particleInPos = false;

		}

		

}
