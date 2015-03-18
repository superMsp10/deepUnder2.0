using UnityEngine;
using System.Collections;

public class pickups : Entity
{

		invManager thisInv;
		public Holdable thisHolding;
		void Start ()
		{
				thisInv = invManager.thisInv;
		}
		void OnTriggerEnter2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = other.GetComponent<Teleport> ();
						teleSpot.teleport (gameObject);
			
				}
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
						if (thisBoost == null)
								Debug.LogError ("no collision boost script attached");
						
						thisBoost.boost (rigidbody2D);
				}
		
		
				if (other.gameObject.tag == "Cannon") {
						cannon thisCannon = other.gameObject.GetComponent<cannon> ();
						if (thisCannon == null)
								Debug.LogError ("no cannon script attached");
						thisCannon.shoot ();
			
			
				}
				if (other.gameObject.tag == "Player") {
						thisInv.changeNextSlot (thisHolding);
						Destroy (gameObject);
			
			
				}


		}
}
