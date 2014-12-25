using UnityEngine;
using System.Collections;

public class CameraConstraint : CameraController
{
		public float amount;

		void Update ()
		{
				if (visible) {
						Transform playerTrans = thisCam.player.transform;
						Debug.Log ("hi");
				}
		}
}

