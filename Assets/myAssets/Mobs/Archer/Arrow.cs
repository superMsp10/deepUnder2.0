using UnityEngine;
using System.Collections;

public class Arrow : Entity
{
		public int damage;
		bool hit;
		public GameObject controller;
		
		void OnCollisionEnter2D (Collision2D coll)
		{
				Mob1 mab = coll.gameObject.GetComponent<Mob1> ();
				if (!hit && coll.gameObject != controller && mab != null) {
						Mob1 player = coll.gameObject.GetComponent<Mob1> ();
						player.takeDmg (damage);
						hit = true;
				}
					
		}
		
}

