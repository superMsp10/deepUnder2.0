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
								controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0f, 0f, rot_z + 250);
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
						int offSet;
						if (turnR) {
								offSet = 2;
						} else {
								offSet = -2;
						}
						Vector3 pos = new Vector3 (controller.weaponHand.transform.position.x + offSet, controller.weaponHand.transform.position.y);
						GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
						g.GetComponent<Entity> ().thisLevel = thisManage.currentLevel;
						g.transform.rotation = controller.weaponHand.transform.parent.rotation;
						Vector3 dir2 = dir - g.transform.position;
						float distance = dir2.magnitude;
						Vector3 direction = dir2 / distance;
			
						g.rigidbody2D.AddForce (dir2 * force);
						controller.rigidbody2D.AddForce (-dir2 * (force / controller.rigidbody2D.mass));
						recharging = true;
						Invoke ("resetShoot", rof);
				}

		}
}
