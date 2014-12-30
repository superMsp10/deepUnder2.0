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

				Vector2 cameraPos = playerCamera.transform.position;
				if (thisLevl.visibleBoundries.Count == 1) {
						CameraController visible = thisLevl.visibleBoundries [0];
						boundryPos = transform.TransformPoint (visible.transform.position);
				} else if (thisLevl.visibleBoundries.Count > 1) {
						changeSize (size--);
				} 
				if (!xWillBeOnScreen (playertPos, boundryPos)) {
						cameraPos = new Vector2 (playertPos.x + xOff, playertPos.y + yOff);
				} else {
						cameraPos = new Vector2 (playerCamera.transform.position.x + xOff, playertPos.y + yOff);
				}
				fp.moveCamera (cameraPos);
		
				/*if (visible.Count < 1) {
						Vector2 offPos = new Vector2 (rawT.x + xOff, rawT.y + yOff);
						fp.moveCamera (offPos);
				} else if (visible.Count == 1) {
						CameraController c = visible [0];
						Vector2 cor = (new Vector3 (0, 0, 0));
						cor.x = c.dir.x * Screen.width;
						cor.y = c.dir.y * Screen.height;

						Vector2 corner = player.ScreenToWorldPoint (cor);
						Vector2 boundryPos = transform.TransformPoint (c.transform.position);

						float fromCornerX = Mathf.Abs (corner.x - rawT.x);
						fromBoundryX = Mathf.Abs (boundryPos.x - rawT.x);
						Vector2 offPos;
						
						if (fromBoundryX < fromCornerX) {
								//	offPos = new Vector2 (1000, rawT.y + yOff);
								
								float cornerToBoundryX = ((boundryPos.x - corner.x) + 10);
								float screeenMiddle = player.ScreenToWorldPoint (new Vector3 (Screen.width / 2, 0, 0)).x;
								offPos = new Vector2 (cornerToBoundryX + screeenMiddle, rawT.y + yOff);

						} else {
								Debug.Log ("hi");
								offPos = new Vector2 (rawT.x + xOff, rawT.y + yOff);

						} 
						
				}*/
				
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

		public bool xWillBeOnScreen (Vector2 thisPos, Vector2 objectPos)
		{
				float thisX = playerCamera.WorldToScreenPoint (thisPos).x;
				float objectX = playerCamera.WorldToScreenPoint (objectPos).x;

				float rightFromScreen = thisX + (Screen.width / 2);
				float leftFromScreen = thisX - (Screen.width / 2);
			
				return (objectX > leftFromScreen && objectX < rightFromScreen);

		}

		void OnDestroy ()
		{


		}

}

