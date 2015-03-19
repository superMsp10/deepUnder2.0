using UnityEngine;
using System.Collections;

public class pickups : Entity
{

		invManager thisInv;
		public Holdable thisHolding;
		public bool pickable = true;
		public int amount = 1;
		public float resetPickup = 5;


		void Start ()
		{
				if (thisLevel == null)
						Debug.LogError ("no Level referenced for this entity: " + gameObject.name);
				thisManage = gameManager.thisM;
				thisInv = invManager.thisInv;
				thisLevel.addEntity (this);
		}
		void OnTriggerEnter2D (Collider2D other)
		{
				thisManage = gameManager.thisM;
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

				if (other.gameObject.tag == "Player" && pickable) {
						if (thisHolding.weapon) {

								thisHolding.gameObject.GetComponent<Bow> ().controller = thisManage.myPlayer.GetComponent<Mob1> ();
						}
						int returnA = thisInv.addHoldable (thisHolding, amount);
						if (returnA == 0) {
								Destroy (gameObject);
						} else {

								amount -= returnA;
						}
			
				}


		}

		
}
