using UnityEngine;
using System.Collections;

public class nextLevelDoor : Door
{

		public level levelChange;
		public LayerMask whatPlayer;
		protected override void extra (GameObject player)
		{
				if (player.layer == LayerMask.NameToLayer ("Player")) {
						gameManager.thisM.levelex (levelChange);
						gameManager.thisM.transferLevelPlayer ();
				}

		
		}

}