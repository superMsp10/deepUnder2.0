using UnityEngine;
using System.Collections;

public class Enemy : Mob1
{
		public LayerMask whatEnemy;
		public GameObject target;
		public float sight;

		void Update ()
		{
				if (target == null) {
						selectTarget ();

				}
				if (grounded) {
				}


		}
		
		public void selectTarget ()
		{
				Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, sight, whatEnemy);
		
				foreach (Collider2D e in enemies) {
						if (e.gameObject != gameObject) {
								target = e.gameObject;
								Debug.Log (e.name);
						}

				}

		}
}
