using UnityEngine;
using System.Collections;

public class CameraManeger : MonoBehaviour
{
		public Camera player;
		public followPlayer fp;
		private gameManager thisManage;
		public float maxSize;
		public float minSize;
		public float size;
		public static CameraManeger thisCamera;

		// Use this for initialization
		void Awake ()
		{
				maxSize = PlayerPrefs.GetFloat ("maxSize", maxSize);
				minSize = PlayerPrefs.GetFloat ("minSize", minSize);
				size = PlayerPrefs.GetFloat ("size", size);
		
				if (thisCamera == null) {
						thisCamera = this;
				}
		}

		void Start ()
		{
				thisManage = gameManager.thisM;
				
				
				

		}

		public void addPlayer (Camera cam)
		{
				player = cam;
				fp = player.GetComponent<followPlayer> ();
				changeSize (size);
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		public void changeSize (float change)
		{
				Debug.Log (size);

				size = change;
				player.orthographicSize = change;


		}

		public void changeHeight (float change)
		{
				player.transform.position.Set (0, change, player.transform.position.z);		
		
		}

		void OnDestroy ()
		{
				PlayerPrefs.SetFloat ("maxSize", maxSize);
				PlayerPrefs.SetFloat ("minSize", minSize);
				PlayerPrefs.SetFloat ("size", size);

		}
}

