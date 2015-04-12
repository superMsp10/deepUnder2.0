using UnityEngine;
using System.Collections;

public class caheckPoint : Door
{
		public Door tele;
		public Transform teleM;
		public int stage = 0;

		public override  void teleport (GameObject player)
		{
				if (player.layer == LayerMask.NameToLayer ("Player")) {

						teleTo = tele.transform;
						tele.gameObject.SetActive (true);
						if (teleM == null) {
								tele.teleTo = gameObject.transform;
						} else {
								tele.teleTo = teleM;
						}
						thisLev.changeStage (stage);
						gameObject.SetActive (false);
						Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                               teleTo.position.y - yOff);
						player.transform.position = telepos;
				}
		}

}

