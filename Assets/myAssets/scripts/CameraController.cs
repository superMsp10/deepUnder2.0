using UnityEngine;
using System.Collections;

public class CameraController : Entity
{
		protected CameraManeger thisCam ;
		public bool visible;
		public bool paused = false;

		void Start ()
		{
				thisCam = CameraManeger.thisCamera;
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
		}

		void LateUpdate ()
		{
				if (!paused) {
						if (renderer.isVisible) {
								visible = true;
								thisCam.addController (this);
						} else {
								visible = false;
								thisCam.removeController (this);
						}
				}
		}

		void OnApplicationFocus (bool focusStatus)
		{
				paused = focusStatus;
		}
}

