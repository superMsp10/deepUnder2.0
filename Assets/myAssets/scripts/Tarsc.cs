using UnityEngine;
using System.Collections;

public class Tarsc : Mob1
{


		void Update ()
		{
			
				if (thisAttributes.HP < 0)
						DestroyEntity (0);

				if (Input.GetKeyDown (KeyCode.Space)) {
						jump (thisAttributes.jump);
			
			
				}
				
			
		}

		void FixedUpdate ()
		{
				bool ground = Physics2D.Linecast (transform.position, groundCheck.position, whatGround); 
				if (!grounded && ground) {
						landed = true;
						grounded = true;

			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
				}

				float move = Input.GetAxis ("Horizontal");
				if (move < 0 && turnR) {
						flip ();
				} else if (move > 0 && !turnR) {
						flip ();
				}
				moveX (move);

		}

}

