using UnityEngine;
using System.Collections;

public class Arrow : Entity
{
		public int damage;
		bool hit;
		
		void OnCollisionEnter2D (Collision2D coll)
		{
				if (!hit && coll.gameObject.GetComponent<Mob1> () != null) {
						Mob1 player = coll.gameObject.GetComponent<Mob1> ();
						player.takeDmg (damage);
						hit = true;
				}
					
		}
		
}

