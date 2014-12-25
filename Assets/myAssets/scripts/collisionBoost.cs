using UnityEngine;
using System.Collections;

public class collisionBoost : MonoBehaviour
{
		public int boostAmount;
		public Vector2 dir;
		public Transform loc;

		public void  boost (Rigidbody2D target)
		{

				float thisX = target.velocity.x / 2;
				float thisY = target.velocity.y / 2;
		
				Vector2 force = new Vector2 (dir.x * boostAmount, dir.y * boostAmount);
				target.AddForceAtPosition (force, transform.position);

		}

}
