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
				rawT = target.transform.position;
				if (visible.Count < 1) {
						Vector2 offPos = new Vector2 (rawT.x + xOff, rawT.y + yOff);
						fp.moveCamera (offPos);
				} else if (visible.Count == 1) {
						CameraController c = visible [0];
						Vector2 cPos = player.WorldToScreenPoint (c.transform.position);
						Vector2 offPos = player.WorldToScreenPoint (new Vector2 (rawT.x + xOff, rawT.y + yOff));
						/*	if (last.x - raw.x < c.xM) {
								offPos = new Vector2 (last.x + xOff, raw.y + yOff);

						}*/
						//	fp.moveCamera (offPos);
						//xOff = Mathf.Abs (Mathf.Abs (raw.x) - Mathf.Abs (p.x));
						Debug.Log (Vector2.Distance (cPos, rawT));

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

