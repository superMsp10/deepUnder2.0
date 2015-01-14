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
				thisAudio = AudioManager.thisAM.playerFX;
				checkNecesseries ();


				cameraM = GetComponentInChildren<CameraManeger> ();
				cameraM.thisLevl = (playLevel)thisLevel;
		}

		public override void updateAnim ()
		{
				thisAnim.SetBool ("grounded", grounded);
				thisAnim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				thisAnim.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));

				if (Mathf.Abs (rigidbody2D.velocity.x) > 1)
						thisAttributes.moving = true;
				else
						thisAttributes.moving = false;
				thisAnim.SetBool ("moving", thisAttributes.moving);
		
		
		}


		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Space)) {
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

}

