using UnityEngine;
using System.Collections.Generic;

public class CameraManeger : MonoBehaviour
{

		public playLevel thisLevl;
		public GameObject target;
		public Camera playerCamera;
		public float minSize;
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
				if (target != null) {

						Vector2 boundryPos;
						Vector2 offSet = new Vector2 (xOff + target.transform.position.x, yOff + target.transform.position.y);
						Vector2 playerPos = refPoint.TransformPoint (offSet);
						CameraController visible;
						Vector2 cameraPos = new Vector2 (playerPos.x, playerPos.y);
				
			

						if (thisLevl.yVisible.Count > 0) {
								cameraPos = new Vector2 (playerPos.x, playerPos.y);
								visible = thisLevl.yVisible [0]; 
								boundryPos = refPoint.TransformPoint (visible.transform.position);
								bool neg = true;
				
								if (visible.dir.y > 0) {
										neg = true;
								} else {
										neg = false;
								}
								if (!yWillBeOnScreen (playerPos, boundryPos, neg)) {
										cameraPos = new Vector2 (cameraPos.x, playerCamera.transform.position.y);
								} 
						} 

				

						if (thisLevl.xVisible.Count > 0) {
								visible = thisLevl.xVisible [0]; 
								boundryPos = refPoint.TransformPoint (visible.transform.position);
								bool neg = true;

								if (visible.dir.x < 0)
										neg = true;
								else
										neg = false;
								if (xWillBeOnScreen (playerPos, boundryPos, neg)) {
										cameraPos = new Vector2 (playerCamera.transform.position.x + xOff, cameraPos.y);
								} 

						}
			
						moveCamera (cameraPos);
				} else
						Destroy (gameObject);
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
				if (left) {
						return (objectX > leftFromScreen);
				} else {
						return (objectX < rightFromScreen);
				}

		}

		public bool yWillBeOnScreen (Vector2 thisPos, Vector2 objectPos, bool higherThanTop)
		{
				float thisY = playerCamera.WorldToScreenPoint (thisPos).y;
				float objectY = playerCamera.WorldToScreenPoint (objectPos).y;
		
				float topOfScreen = thisY + (Screen.height / 2);
				float bottomOfScreen = thisY - (Screen.height / 2);
				if (higherThanTop) {
						return (objectY > topOfScreen);
				} else {
						return (objectY < bottomOfScreen);
				}
		
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

