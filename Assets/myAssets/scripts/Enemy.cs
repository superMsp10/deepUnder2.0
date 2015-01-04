using UnityEngine;
using System.Collections;

public class Enemy : Mob1
{
		public LayerMask whatEnemy;
		public GameObject target;
		public float sight;
		public bool despawnWithDistance;


		public void selectTarget ()
		{
				Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, sight, whatEnemy);
		
				foreach (Collider2D e in enemies) {
						if (e.gameObject != gameObject) {
								target = e.gameObject;
								return;
						}

				}

		}

		void FixedUpdate ()
		{
				checkGround ();
				TargetSight ();

		}


		protected	void checkGround ()
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

		}
		protected	void TargetSight ()
		{
				if (target != null) {
						if (Vector2.Distance (target.transform.position, transform.position)
								> thisAttributes.optTargetRange) {
								moveAi ();
						}
			
						if (Vector2.Distance (target.transform.position, transform.position) > sight) {
								target = null;
								if (despawnWithDistance) {
										gameObject.SetActive (false);
								}
				
				
						}
				} else
						selectTarget ();

		}
		
		public void moveAi ()
		{

				if (Mathf.Abs (target.transform.position.x - transform.position.x) > 0) {
						float move = 0;
						if (target.transform.position.x < transform.position.x) {
								move = (Vector2.right.x * -1);
						} else if (target.transform.position.x > transform.position.x) {
								move = (Vector2.right.x);
						}
			
						if (move < 0 && turnR) {
								flip ();
						} else if (move > 0 && !turnR) {
								flip ();
						}
						moveX (move);
				
				}
				if (target.transform.position.y > transform.position.y) {

						jump (thisAttributes.jump + Random.Range (-30, 200));


				}


		}

}
