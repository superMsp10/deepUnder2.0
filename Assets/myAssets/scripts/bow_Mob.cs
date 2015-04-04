using UnityEngine;
using System.Collections;

public class bow_Mob : Bow
{

		public GameObject target;
		public bool turnR;

		void Update ()
		{
				if (target != null) {

						Vector3 targetPos = target.transform.position;
						Vector3 diff = targetPos - transform.position;

						
						diff.Normalize ();
			
						float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
						
						if (controller.turnR) {
								turnR = true;
								controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0f, 0f, (rot_z - 270) * -1);
						} else {
								turnR = false;
								controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0f, 0f, rot_z - 270);
						}

						
				
								
				}
		}
		
		public  void attack ()
		{
			
				if (!recharging) {
					
						dir = controller.attackArea.transform.position;
					
						shootSound ();

						Vector3 pos = new Vector3 (controller.weaponHand.transform.position.x, controller.weaponHand.transform.position.y);
						GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
						g.GetComponent<Arrow> ().thisLevel = thisManage.currentLevel;
						if (turnR) {
								g.transform.rotation = Quaternion.Inverse (controller.weaponHand.transform.parent.rotation);
						} else {
								g.transform.rotation = controller.weaponHand.transform.parent.rotation;

						}
						
						
						Vector3 dir2 = dir - g.transform.position;
						
			
						g.rigidbody2D.AddForce (dir2 * force);
						controller.rigidbody2D.AddForce (-dir2 * (force / controller.rigidbody2D.mass));
						recharging = true;
						Invoke ("resetShoot", rof);
				}

		}
}
