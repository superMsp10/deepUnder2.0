using UnityEngine;
using System.Collections;

public class stageDoor : Door
{

		public int stage = 0;
		public LayerMask whatPlayer;

		protected override void extra (GameObject player)
		{
				if (player.layer == LayerMask.NameToLayer ("Player")) {
						thisLev.changeStage (stage);
				}
		
		}
}

