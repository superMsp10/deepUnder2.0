using UnityEngine;
using System.Collections;

public class groth : Dummy
{


		public override void moveAi ()
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
						if (flipMob) {
								if (move < 0 && turnR) {
										flip ();
								} else if (move > 0 && !turnR) {
										flip ();
								}
				
						}
						moveX (move);
				}



				jump (thisAttributes.jump);
			
				
		
		
		}

}
