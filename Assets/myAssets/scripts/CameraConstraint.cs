using UnityEngine;
using System.Collections;

public class CameraConstraint : CameraController
{
		public float amount;
		public bool negative;

		void Update ()
		{
				float movePos = Mathf.Abs (thisManage.myPlayer.transform.position.x) - Mathf.Abs (transform.position.x);
				if (negative)
						movePos *= (-1);
				if (visible) {
						thisCam.fp.move = false;
				} 
				if (movePos > thisCam.size / 2) {
						thisCam.fp.move = true;

				}
		}

		
}

