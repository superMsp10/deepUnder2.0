using UnityEngine;
using System.Collections;

public class Tarsc : Mob1
{
		CameraManeger cameraM;

		void Start ()
		{
		
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();

				checkNecesseries ();


				cameraM = GetComponentInChildren<CameraManeger> ();
				cameraM.thisLevl = (playLevel)thisLevel;
		}

		public override void updateAnim ()
		{
				thisAnim.SetBool ("grounded", grounded);
				thisAnim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				thisAnim.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));
				if (Mathf.Abs (rigidbody2D.velocity.x) > 0.1)
						thisAttributes.moving = true;
				else
						thisAttributes.moving = false;
		
		
		}
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Space)) {
						jump (thisAttributes.jump);
				}
				if (animated)
						updateAnim ();
				checkDead ();
				checkFacing ();
							
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
				if (yGround - nGround >= 0) {
						ground = true;
						
				} else {
						ground = false;
						
				}
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

