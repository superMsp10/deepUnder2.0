using UnityEngine;
using System.Collections;

public class Enemy : Mob1
{
		public LayerMask whatEnemy;
		public GameObject target;
		public float sight;
		public bool jumpedSound = false;

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

		public override void jump (int jumpF)
		{
		
				if (grounded) {
						rigidbody2D.AddForce (new Vector2 (0, jumpF));
						if (!jumpedSound) {
								playJumpSound ();
								jumpedSound = true;
						} else {
								Invoke ("resetJump", 0.5f);
						}
			
				} 
		
		}

		new protected void checkFacing ()
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
		
		protected virtual void TargetSight ()
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

		

		public void checkLooking ()
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

				}

		}

		public void resetJump ()
		{
				jumpedSound = false;
		}

}
