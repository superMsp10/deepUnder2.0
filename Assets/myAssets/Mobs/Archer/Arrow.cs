using UnityEngine;
using System.Collections;

public class Arrow : Entity
{
		public int damage;

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
						/*	float thisX = rigidbody2D.velocity.x / 2;
			float thisY = rigidbody2D.velocity.y / 2;
			
			Vector2 force = new Vector2 (thisX +((thisBoost.multiX) * thisBoost.boostAmount)
			                             , thisY + ((-thisBoost.multiY) * thisBoost.boostAmount));
			rigidbody2D.AddForceAtPosition (force, transform.position);

*/
						thisBoost.boost (rigidbody2D);
				}
		
		
				if (other.gameObject.tag == "Player") {
						Mob1 mob = other.gameObject.GetComponent<Mob1> ();
						if (mob == null)
								Debug.LogError ("no cannon script attached");
						Debug.Log ("hi");
			
			
				}
		
		
		
		
		}
		
}

