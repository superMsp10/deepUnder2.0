using UnityEngine;
using System.Collections;

public class collisionBoost : MonoBehaviour
{

		public Vector2 dir;


		public void  boost (Rigidbody2D target)
		{

			
				target.velocity = dir;

		}

}
