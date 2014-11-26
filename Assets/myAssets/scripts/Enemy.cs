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


		}
}
