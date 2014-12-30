using UnityEngine;
using System.Collections;

public class stageDoor : Door
{

		public int stage = 0;
	
		public virtual void teleport (Transform player)
		{
		
				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                               teleTo.position.y - yOff);
				player.position = telepos;
				thisLev.changeStage (stage);
		}
}

