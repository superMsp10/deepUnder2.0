using UnityEngine;
using System.Collections;

public class energyball : Arrow
{

		public LayerMask gravityEffect;
		public int distance;
		public int force = 1000;


		void FixedUpdate ()
		{

				Collider2D[] hit = Physics2D.OverlapCircleAll (transform.position, distance,
		                                               gravityEffect);

				foreach (Collider2D c in hit) {
						Rigidbody2D r = c.rigidbody2D;
						if (r != null) {
								r.AddForce ((transform.position - c.transform.position) * (force / Vector2.Distance (transform.position, c.transform.position)));
						}
				}
	
		}
}
