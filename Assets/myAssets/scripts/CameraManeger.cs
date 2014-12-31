using UnityEngine;
using System.Collections.Generic;

public class CameraManeger : MonoBehaviour
{

		public playLevel thisLevl;
		public GameObject target;
		public Camera playerCamera;
		public float minSize;
		public float size;
		public float xOff;
		public float maxSize;
		public float yOff;
		public	float fromBoundryX;
		private gameManager thisManage;
		Transform refPoint;
		float lastXPos;




		void Start ()
		{
				transform.parent = null;
				thisManage = gameManager.thisM;
				thisLevl = (playLevel)thisManage.currentLevel;
				playerCamera = GetComponent<Camera> ();
				xOff = Screen.width * xOff;
				yOff = Screen.height * yOff;
				refPoint = thisManage.transform;
		}
	

		void Update ()
		{


				Vector2 boundryPos;
				Vector2 playerPos = refPoint.TransformPoint (target.transform.position);
				CameraController visible;
				bool neg = true;
				Vector2 cameraPos = new Vector2 (playerPos.x + xOff, playerPos.y + yOff);
				
				if (thisLevl.visibleBoundries.Count == 1) {
						boundryPos = refPoint.TransformPoint (thisLevl.stageBoundires [0].transform.position);
						visible = thisLevl.visibleBoundries [0];
						boundryPos = refPoint.TransformPoint (visible.transform.position);
						if (visible.dir.x != 0) {
								if (visible.dir.x < 0)
										neg = true;
								else
										neg = false;
								if (xWillBeOnScreen (playerPos, boundryPos, neg)) {
										cameraPos = new Vector2 (playerCamera.transform.position.x + xOff, playerPos.y + yOff);
								} 
						} 
						
				} else if (thisLevl.visibleBoundries.Count > 1) {
						changeSize (size--);
				} 
				moveCamera (cameraPos);
		}
		

		public void changeSize (float change)
		{
				if (change > minSize) {
						size = change;
						playerCamera.orthographicSize = change;
				}

		}



		public bool onScreenX (Vector2 pos)
		{
				Vector2 p = playerCamera.WorldToScreenPoint (pos);
				return(p.x > 0 && p.x < Screen.width);

		}

		public bool xWillBeOnScreen (Vector2 thisPos, Vector2 objectPos, bool left)
		{
				float thisX = playerCamera.WorldToScreenPoint (thisPos).x;
				float objectX = playerCamera.WorldToScreenPoint (objectPos).x;

				float rightFromScreen = thisX + (Screen.width / 2);
				float leftFromScreen = thisX - (Screen.width / 2);
				if (left)
						return (objectX > leftFromScreen);
				else
						return (objectX < rightFromScreen);

		}

		public void moveCamera (Vector2 Pos)
		{
				Vector3 p = new Vector3 (Pos.x, Pos.y, transform.position.z);
				transform.position = p;
		}

		void OnDestroy ()
		{


		}

}

