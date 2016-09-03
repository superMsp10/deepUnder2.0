using UnityEngine;
using System.Collections;

public class Door : Teleport
{

		public override  void teleport (GameObject player)
		{
				if (teleTo != null) {
						Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
			                               teleTo.position.y - yOff);
						player.transform.position = telepos;
						extra (player);
				}
		}

		protected virtual void extra (GameObject player)
		{
		
		}
}