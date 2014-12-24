using UnityEngine;
using System.Collections;

public class Dummy : Enemy
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
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
		
				if (target != null) {
						if (Vector2.Distance (target.transform.position, transform.position)
								> thisAttributes.optTargetRange) {
								moveAi ();
						}
			
				} else
						selectTarget ();
		
		
		
		}
	
		public void moveAi ()
		{
		
				if (Mathf.Abs (target.transform.position.x - transform.position.x) > 1) {
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
			
						jump (thisAttributes.jump + Random.Range (0, 20));
			
			
				}
		
		
		}
	
}
