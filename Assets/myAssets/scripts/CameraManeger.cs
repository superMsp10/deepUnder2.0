using UnityEngine;
using System.Collections;

public class CameraManeger : MonoBehaviour
{
		public Camera player;
		private gameManager thisManage;
		public float maxSize;
		public float minSize;
		public float size;
		public static CameraManeger thisCamera;

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
				maxSize = PlayerPrefs.GetFloat ("maxSize", maxSize);
				minSize = PlayerPrefs.GetFloat ("minSize", minSize);
				size = PlayerPrefs.GetFloat ("size", size);

				

		}

		public void addPlayer (Camera cam)
		{
				player = cam;
				changeSize (size);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void changeSize (float change)
		{
				size = change;
				player.orthographicSize = change;
				changeHeight (size / 2);


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

