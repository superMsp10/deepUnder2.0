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
				Vector2 raw = target.transform.position;
				
				if (visible.Count < 1) {
						Vector2 offPos = new Vector2 (raw.x + xOff, raw.y + yOff);
						fp.moveCamera (offPos);
				} else if (visible.Count == 1) {
						Vector2 p = visible [0].transform.position;
						Vector2 offPos = new Vector2 (raw.x + xOff, raw.y + yOff);

						xOff = Mathf.Abs (Mathf.Abs (raw.x) - Mathf.Abs (p.x));
						fp.moveCamera (offPos);
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

