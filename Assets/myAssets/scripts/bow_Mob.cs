using UnityEngine;
using System.Collections;

public class bow_Mob : Bow
{

		public GameObject target;

		void Update ()
		{
				if (target == null) {

						if (rotate) {
								controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, 0);
						} else {
								Vector3 targetPos = target.transform.position;

								if (rotate) {
										controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, targetPos.y / Mathf.PI);
								}
						}
				}
		}
		public  void attack ()
		{
				Vector3 targetPos = target.transform.position;
		
				if (rotate) {
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, targetPos.y / Mathf.PI);
			
			
				}

				if (!recharging) {
						dir = controller.attackArea.transform.position;
						Vector2 pos = new Vector2 (controller.weaponHand.transform.position.x, controller.weaponHand.transform.position.y);
			
						GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
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
