using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{

		
		public Transform teleTo;
		public float xOff = 0;
		public float yOff = 0;
		public playLevel thisLev;
		public gameManager thisM;

		public virtual void teleport (GameObject player)
		{
				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                                       teleTo.position.y - yOff);
				player.transform.position = telepos;
				
		}
}
