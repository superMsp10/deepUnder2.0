using UnityEngine;
using System.Collections.Generic;

public class CameraManeger : MonoBehaviour
{

		public playLevel thisLevl;
		public Camera playerCamera;
		public followPlayer fp;
		private GameObject playerGameObject;
		private Vector2 playertPos;
		/// <summary>
		/// 	/// </summary>
		public float minSize;
		public float size;
		public float xOff;
		public float maxSize;
		public float yOff;
		public	float fromBoundryX;
		public static CameraManeger thisCamera;
		private gameManager thisManage;
		float lastXPos;


		// Use this for initialization
		void Awake ()
		{
				if (thisCamera == null) {
						thisCamera = this;
				}
		}

		void Start ()
		{
				thisManage = gameManager.thisM;
				thisLevl = (playLevel)thisManage.currentLevel;
				xOff = Screen.width * xOff;
				yOff = Screen.height * yOff;

		}

		public void addPlayer (Camera cam)
		{
				playerCamera = cam;
				fp = playerCamera.GetComponent<followPlayer> ();
				changeSize (size);
				playerGameObject = fp.target;
		}



		void Update ()
		{
				playertPos = transform.TransformPoint (playerGameObject.transform.position);
				Vector2 boundryPos;
				boundryPos = transform.TransformPoint (thisLevl.stageBoundires [0].transform.position);
				CameraController visible;
				bool neg = true;
				Vector2 cameraPos = new Vector2 (playertPos.x + xOff, playertPos.y + yOff);
				if (thisLevl.visibleBoundries.Count == 1) {
						visible = thisLevl.visibleBoundries [0];
						boundryPos = transform.TransformPoint (visible.transform.position);
						if (visible.dir.x != 0) {
								if (visible.dir.x < 0)
										neg = true;
								else
										neg = false;
								if (xWillBeOnScreen (playertPos, boundryPos, neg)) {
										cameraPos = new Vector2 (playerCamera.transform.position.x + xOff, playertPos.y + yOff);
								} 
						} 
						
				} else if (thisLevl.visibleBoundries.Count > 1) {
						changeSize (size--);
				} 
				fp.moveCamera (cameraPos);

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

		void OnDestroy ()
		{


		}

}

