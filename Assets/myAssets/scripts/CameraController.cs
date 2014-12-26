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

		void Update ()
		{
				if (!paused) {

						if (renderer.isVisible) {
								if (visible != true)
										thisCam.addController (this);
								visible = true;
				
						} else {
								if (visible = true)
										thisCam.removeController (this);

								visible = false;

						}
				}
		}

		void OnApplicationFocus (bool focusStatus)
		{

				paused = ! focusStatus;
		}
}

