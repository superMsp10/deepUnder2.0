using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{

		
		public Transform teleTo;
		public float xOff = 0;
		public float yOff = 0;
		public playLevel thisLev;

		public virtual void teleport (Transform player)
		{

				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                                       teleTo.position.y - yOff);
				player.position = telepos;
		}
	                   
}
