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
		public	float fromBoundry;
		public List<CameraController> visible;
		public static CameraManeger thisCamera;
		private GameObject target;
		private gameManager thisManage;
		Vector2 lastP ;
		Vector2 rawT;

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

		public void addController (CameraController cam)
		{
				visible.Add (cam);
	
		}

		public void removeController (CameraController cam)
		{
				visible.Remove (cam);
		
		}

		// Update is called once per frame
		void LateUpdate ()
		{
				lastP = rawT;
				rawT = transform.TransformPoint (target.transform.position);
				if (visible.Count < 1) {
						Vector2 offPos = new Vector2 (rawT.x + xOff, rawT.y + yOff);
						fp.moveCamera (offPos);
				} else if (visible.Count == 1) {
						CameraController c = visible [0];
						Vector2 cor = (new Vector3 (0, 0, 0));
						if (c.dir.x == 0)
								cor.x = 0;
						else if (c.dir.x == 1)
								cor.x = Screen.width;
						if (c.dir.y == 0)
								cor.y = 0;
						else if (c.dir.y == 1)
								cor.y = Screen.height;
						Vector2 corner = player.ScreenToWorldPoint (cor);
						Vector2 boundryPos = transform.TransformPoint (c.transform.position);
						float fromCorner = Vector2.Distance (corner, rawT);
						fromBoundry = Vector2.Distance (boundryPos, rawT);
						if (fromBoundry >= fromCorner) {						
								Vector2 offPos = new Vector2 (rawT.x + xOff, rawT.y + yOff);
								Debug.Log ("move");
								fp.moveCamera (offPos);
						} else {
								Debug.Log ("not move");

								Vector2 offPos = new Vector2 (lastP.x + xOff, lastP.y + yOff);
								fp.moveCamera (offPos);

						}
				}
				
		}

		public void changeSize (float change)
		{

				size = change;
				player.orthographicSize = change;


		}

		public void changeHeight (float change)
		{
				player.transform.position.Set (0, change, player.transform.position.z);		
		
		}

		void OnDestroy ()
		{

				//PlayerPrefs.SetFloat ("xOff", xOff);
				//PlayerPrefs.SetFloat ("yOff", yOff);

		}
}

