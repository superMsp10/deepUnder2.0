using UnityEngine;
using System.Collections;

public class stageDoor : Door
{

		public int stage = 0;

		protected override void extra (GameObject player)
		{
				if (player.layer == LayerMask.NameToLayer ("Player")) {
						thisLev.changeStage (stage);
				}
		
		}
}

