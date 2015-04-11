using UnityEngine;
using System.Collections;

public class caheckPoint : Door
{
		public Door tele;
		public Transform teleM;

		public override  void teleport (GameObject player)
		{
				teleTo = tele.transform;
				tele.gameObject.SetActive (true);
				if (teleM == null) {
						tele.teleTo = gameObject.transform;
				} else {
						tele.teleTo = teleM;
				}
				gameObject.SetActive (false);
				Vector3 telepos = new Vector2 (teleTo.position.x - xOff,
		                               teleTo.position.y - yOff);
				player.transform.position = telepos;
		}
		

}

