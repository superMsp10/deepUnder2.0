using UnityEngine;
using System.Collections;

public class Door : Teleport
{

		public virtual void teleport (Transform player)
		{
		
				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                               teleTo.position.y - yOff);
				player.position = telepos;
		}
		
}

