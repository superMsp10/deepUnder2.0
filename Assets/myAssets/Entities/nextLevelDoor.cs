using UnityEngine;
using System.Collections;

public class nextLevelDoor : Door
{

		public level levelChange;

		public override void teleport (Transform player)
		{
		
				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                               teleTo.position.y - yOff);
				player.position = telepos;
				gameManager.thisM.levelex (levelChange);
		}

}

