using UnityEngine;
using System.Collections.Generic;

public class CameraManeger : MonoBehaviour
{

		public int visibleBoundries;
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
		public  CameraManeger thisCamera;
		private gameManager thisManage;
		float lastXPos;
		public bool paused = false;


		// Use this for initialization
		void Awake ()
		{
			
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
				if (fp == null) {
						Debug.Log ("no follow player attached");
				}
				if (fp.target == null) {
						Debug.Log (transform.TransformPoint (playerGameObject.transform.position));
				}
				playerGameObject = fp.target;
				changeSize (size);
		}



		void Update ()
		{
				playertPos = transform.TransformPoint (playerGameObject.transform.position);
				Vector2 boundryPos = transform.TransformPoint (thisLevl.stageBoundires [0].transform.position);
				//	Debug.Log (amountDifference (playertPos.x, boundryPos.x, Screen.width / 2));
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

				size = change;
				playerCamera.orthographicSize = change;


		}



		public bool onScreenX (Vector2 pos)
		{
				Vector2 p = playerCamera.WorldToScreenPoint (pos);
				return(p.x > 0 && p.x < Screen.width);

		}

		public bool amountDifference (float corX, float obPos, float amount)
		{
				return  (Mathf.Abs (corX - obPos) > amount);
		
		}

		void OnDestroy ()
		{


		}
		void OnApplicationFocus (bool focusStatus)
		{
		
				paused = ! focusStatus;
		}
}

