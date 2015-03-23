using UnityEngine;
using System.Collections;

public class Arrow : Entity
{
		public int damage;

		
		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.tag == "Player") {
						Mob1 player = coll.gameObject.GetComponent<Mob1> ();
						player.takeDmg (damage);
						damage = 0;
				}
					
		}
		
}

