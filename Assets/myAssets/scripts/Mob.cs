using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour
{
		public Rigidbody2D thisRigid;

		void Start ()
		{

				thisRigid = GetComponent<Rigidbody2D> ();
		
		}

		void OnTriggerEnter2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = (Teleport)other.GetComponent ("Teleport");
						Vector3 teleTo = teleSpot.teleto.transform.position;
						this.transform.position = new Vector3 (teleTo.x - teleSpot.xOff,
			                                      teleTo.y - teleSpot.yOff, teleTo.z - teleSpot.zOff);
						if (teleSpot.nextLevel) {

				
						}
				}
		
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.GetComponent<collisionBoost> ();
						thisRigid.AddForce (this.transform.position * (-1 * thisBoost.boostAmount));
				}
		
				if (other.gameObject.tag == "Enemy") {
			
				}
		}


}
