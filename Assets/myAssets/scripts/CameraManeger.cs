using UnityEngine;
using System.Collections.Generic;

public class CameraManeger : MonoBehaviour
{
		public Camera player;
		public followPlayer fp;
		public float minSize;
		public float size;
		public float xOff;
		public float maxSize;
		public float yOff;
		public	float fromBoundryX;
		public List<CameraController> visible;
		public static CameraManeger thisCamera;
		private GameObject target;
		private gameManager thisManage;
		Vector2 lastP ;
		Vector2 rawT;
		float lastXPos;
		public bool paused = false;


		// Use this for initialization
		void Awake ()
		{
			
				//xOff = PlayerPrefs.GetFloat ("xOff", xOff);
				//	yOff = PlayerPrefs.GetFloat ("yOff", yOff);
				if (thisCamera == null) {
						thisCamera = this;
				}
		}

		void Start ()
		{
				thisManage = gameManager.thisM;
				changeSize (maxSize);				
				
				

		}

		public void addPlayer (Camera cam)
		{
				player = cam;
				fp = player.GetComponent<followPlayer> ();
				changeSize (size);
				target = fp.target;
		}



		// Update is called once per frame
		void LateUpdate ()
		{
				lastP = rawT;
				rawT = transform.TransformPoint (target.transform.position);
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
				player.orthographicSize = change;


		}

		void moveCamera (Vector2 offPos)
		{

				fp.moveCamera (offPos);

		}

		public bool checkX (Vector2 pos)
		{
				Vector2 p = player.WorldToScreenPoint (pos);
				return(p.x > 0 && p.x < Screen.width);

		}

		public bool checkX (float corX, float obPos, float amount)
		{
				return  (Mathf.Abs (corX - obPos) > amount);
		
		}

		void OnDestroy ()
		{

				//PlayerPrefs.SetFloat ("xOff", xOff);
				//PlayerPrefs.SetFloat ("yOff", yOff);

		}
		void OnApplicationFocus (bool focusStatus)
		{
		
				paused = ! focusStatus;
		}
}

