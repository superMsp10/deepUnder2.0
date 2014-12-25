using UnityEngine;
using System.Collections;

public class Tarsc : Mob1
{


		void Update ()
		{
			
				if (thisAttributes.HP < 0)
						DestroyEntity (0);
				if (transform.position.y < thisLevel.deathHeight)
						thisAttributes.HP = 0;
				if (Input.GetKeyDown (KeyCode.Space)) {
						jump (thisAttributes.jump);
				}
				if (Mathf.Abs (rigidbody2D.velocity.x) > 0.1)
						thisAttributes.moving = true;
				else
						thisAttributes.moving = false;
				updateAnim ();

				if (detectedFacing) {
						if (thisAttributes.moving && rigidbody2D.velocity.y > -20) {
								frontBody.gameObject.SetActive (false);
								sideBody.gameObject.SetActive (true);
						} else {
								sideBody.gameObject.SetActive (false);
								frontBody.gameObject.SetActive (true);
						}
				}			
		}

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

				float move = Input.GetAxis ("Horizontal");
				if (move < 0 && turnR) {
						flip ();
				} else if (move > 0 && !turnR) {
						flip ();
				}
				moveX (move);

		}

}

