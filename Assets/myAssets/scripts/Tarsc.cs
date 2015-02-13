using UnityEngine;
using System.Collections;

public class Tarsc : Mob1
{
		CameraManeger cameraM;
		public Transform[] fGroundCheck;
		public Transform[] lGroundCheck;

		void Start ()
		{
		
				thisManage = gameManager.thisM;
				changeLevel (thisLevel);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				thisAudio = AudioManager.thisAM.playerFX;
				checkNecesseries ();


				cameraM = GetComponentInChildren<CameraManeger> ();
				cameraM.thisLevl = (playLevel)thisLevel;
		}

		public override void changeLevel (level level)
		{
				thisLevel = level;
				thisLevel.addEntity (this);
		
		}

		public override void updateAnim ()
		{
				thisAnim.SetBool ("grounded", grounded);
				thisAnim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				thisAnim.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));

				if (Mathf.Abs (rigidbody2D.velocity.x) > 1) {
						thisAttributes.moving = true;
						
				} else {
						thisAttributes.moving = false;
				}
				thisAnim.SetBool ("moving", thisAttributes.moving);
		
		}


		void Update ()
		{
				if (Input.GetButtonDown ("Jump")) {
						jump (thisAttributes.jump);
				}
				if (animated)
						updateAnim ();
				checkFacing ();
				checkDead ();
							
		}

		void FixedUpdate ()
		{
				checkground ();
				float move = Input.GetAxis ("Horizontal");
				if (move < 0 && turnR) {
						flip ();
				} else if (move > 0 && !turnR) {
						flip ();
				}
				moveX (move);

		}

		protected override void checkground ()
		{
				int yGround = 0;
				int nGround = 0;

				if (front) {
						foreach (Transform t in fGroundCheck) {
								if (Physics2D.Linecast (transform.position, t.position, whatGround))
										yGround++;
								else
										nGround ++;
						}
				} else {
						foreach (Transform t in lGroundCheck) {
								if (Physics2D.Linecast (transform.position, t.position, whatGround))
										yGround++;
								else
										nGround ++;
						}

				}
				
				bool ground;
				if (yGround > 0)
						ground = true;
				else
						ground = false;
		
				if (!grounded && ground) {
						landed = true;
						grounded = true;
			
						playLandSound ();
			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
				}
		}

		void OnDestroy ()
		{
				if (cameraM != null)
						Destroy (cameraM.gameObject);
		}

}

