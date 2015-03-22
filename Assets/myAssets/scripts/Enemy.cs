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
				if (enemies.Length >= 1) {
						getTarget:
						target = enemies [Random.Range (0, enemies.Length)].gameObject;
						if (target == this.gameObject) {
								goto getTarget;
						}
				}
		}

		void FixedUpdate ()
		{
				checkground ();
				TargetSight ();

		}


		
		protected virtual void TargetSight ()
		{
				if (target != null) {
						if (Vector2.Distance (target.transform.position, transform.position)
								> thisAttributes.optTargetRange) {
								//moveAi ();
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
		
		public void moveAi ()
		{

				Vector2 targetPos = thisManage.transform.TransformPoint (target.transform.position);
				Vector2 thisPos = thisManage.transform.TransformPoint (transform.position);

				if (Mathf.Abs (targetPos.x - thisPos.x) > 0) {
						float move = 0;
						
						if (targetPos.x < thisPos.x) {
								move = (Vector2.right.x * -1);
							
						} else if (targetPos.x > thisPos.x) {
								move = (Vector2.right.x);
								
						}
						if (move < 0 && turnR) {
								flip ();
						} else if (move > 0 && !turnR) {
								flip ();
						}
						moveX (move);
				
				}
				if (targetPos.y > thisPos.y || targetPos.y < thisPos.y) {
						jump (thisAttributes.jump * Random.Range (0, 30));


				}


		}

}
