using UnityEngine;
using System.Collections;

public class collisionBoost : MonoBehaviour
{
		public int MultiplierX;
		public int MultiplierY;
		public float boostAmount;
		public float randomrange = 0;
		public Vector2 dir;
		public Transform loc;

		public void  boost (Rigidbody2D target)
		{

				float thisX = target.velocity.x / 2;
				float thisY = (target.velocity.y / 2) * -1;
				Vector2 tagetVeloMulti = new Vector2 (thisX * MultiplierX, thisY * MultiplierY);
				Vector2 boost = new Vector2 (dir.x * (boostAmount + Random.Range (0, randomrange)), dir.y * (boostAmount + Random.Range (0, randomrange)));
				Vector2 force = (tagetVeloMulti + boost);
				target.AddForceAtPosition (force, transform.position);

		}

}
