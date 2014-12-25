using UnityEngine;
using System.Collections;

public class CameraController : Entity
{
		protected CameraManeger thisCam ;
		public bool visible;

		void Start ()
		{
				thisCam = CameraManeger.thisCamera;
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
		}

		void LateUpdate ()
		{
				if (renderer.isVisible) {
						visible = true;
				} else {
						visible = false;
				}
		}
}

