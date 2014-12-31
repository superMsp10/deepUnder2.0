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
		public bool playableLevel;
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
				if (thisManage == null)
						Debug.LogError ("thismanage is null");
				if (thisManage.currentLevel as playLevel != null) {
						thisLevl = (thisManage.currentLevel)as playLevel;
						playableLevel = true;
				} else {
						playableLevel = false;
				}
				xOff = Screen.width * xOff;
				yOff = Screen.height * yOff;

		}

		public void addPlayer (Camera cam)
		{
				playerCamera = cam;
				fp = playerCamera.GetComponent<followPlayer> ();
				fp.thisLevel = thisLevl;
				changeSize (size);
				playerGameObject = fp.target;
				playableLevel = true;
				if (thisManage.currentLevel == null)
						Debug.Log ("current Level is null cannot add camera of the player");
				thisLevl = (thisManage.currentLevel)as playLevel;
				if (thisLevl == null)
						Debug.Log ("this level cannot be usedf as playable Level : " + thisLevl.gameObject.name);

		}



		void Update ()
		{
				if (playableLevel) {
						playertPos = transform.TransformPoint (playerGameObject.transform.position);
						Vector2 boundryPos;
						boundryPos = transform.TransformPoint (thisLevl.stageBoundires [0].transform.position);
						CameraController visible;
				
						Vector2 cameraPos = new Vector2 (playertPos.x + xOff, playertPos.y + yOff);
						if (thisLevl.visibleBoundries.Count == 1) {
								visible = thisLevl.visibleBoundries [0];
								boundryPos = transform.TransformPoint (visible.transform.position);
								if (visible.dir.x != 0) {
										bool neg = true;
										if (visible.dir.x < 0)
												neg = true;
										else
												neg = false;
										if (xWillBeOnScreen (playertPos, boundryPos, neg)) {
												cameraPos = new Vector2 (playerCamera.transform.position.x + xOff, playertPos.y + yOff);
										} 
								}
								if (visible.dir.y != 0) {
										bool neg = true;
										if (visible.dir.y < 0)
												neg = true;
										else
												neg = false;
										if (yWillBeOnScreen (playertPos, boundryPos, neg)) {
												cameraPos = new Vector2 (playertPos.x + xOff, playerCamera.transform.position.y + yOff);
										}  
								}
						} else if (thisLevl.visibleBoundries.Count > 1) {
								changeSize (size--);
						} 
						fp.moveCamera (cameraPos);

						
				}
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

		public bool yWillBeOnScreen (Vector2 thisPos, Vector2 objectPos, bool up)
		{
				float thisY = playerCamera.WorldToScreenPoint (thisPos).y;
				float objectY = playerCamera.WorldToScreenPoint (objectPos).y;
			
				float upFromScreen = thisY + (Screen.height / 2);
				float downFromScreen = thisY - (Screen.height / 2);
				if (up)
						return (objectY > upFromScreen);
				else
						return (objectY < downFromScreen);
			
		}

		void OnDestroy ()
		{


		}

}

