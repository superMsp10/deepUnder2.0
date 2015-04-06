using UnityEngine;
using System.Collections;

public class Arrow : Entity
{
		public int damage;
		bool hit;
		public GameObject controller;
		
		void OnCollisionEnter2D (Collision2D coll)
		{

				if (coll.gameObject.tag == "Destroyable") {
						Resource temp = coll.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf ();
				}
				Mob1 mab = coll.gameObject.GetComponent<Mob1> ();
				if (!hit && coll.gameObject != controller && mab != null) {
						Mob1 player = coll.gameObject.GetComponent<Mob1> ();
						player.takeDmg (damage);
						hit = true;
				}
					
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
		

		
		}

}

