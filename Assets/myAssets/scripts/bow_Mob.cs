using UnityEngine;
using System.Collections;

public class bow_Mob : Bow
{

		public GameObject target;

		void Update ()
		{
				if (target != null) {

						Vector3 targetPos = target.transform.position;
						Vector3 diff = targetPos - transform.position;
						diff.Normalize ();
			
						float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0f, 0f, rot_z - 270);

				
								
				}
		}
		
		public  void attack ()
		{
			

				if (!recharging) {
					
						dir = controller.attackArea.transform.position;
						Vector2 pos = new Vector2 (controller.weaponHand.transform.position.x + 2, controller.weaponHand.transform.position.y);
			
						GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
						g.GetComponent<Entity> ().thisLevel = thisManage.currentLevel;
						g.transform.rotation = controller.weaponHand.transform.parent.rotation;
						Vector2 dir2 = dir - pos;
						float distance = dir2.magnitude;
						Vector2 direction = dir2 / distance;
			
						g.rigidbody2D.AddForce (dir2 * force);
						controller.rigidbody2D.AddForce (-dir2 * (force / controller.rigidbody2D.mass));
						recharging = true;
						Invoke ("resetShoot", rof);
				}

		}
}
