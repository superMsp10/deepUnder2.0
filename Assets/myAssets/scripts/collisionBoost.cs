using UnityEngine;
using System.Collections;

public class collisionBoost : MonoBehaviour
{

		public Vector2 dir;
		public bool calcVelo = false;
		public Transform to;
		public float toBoost = 1.5f;

		public void  boost (Rigidbody2D target)
		{

				if (calcVelo) {
						target.velocity = (to.position - target.transform.position) * toBoost;

				} else
						target.velocity = dir;

		}

}
