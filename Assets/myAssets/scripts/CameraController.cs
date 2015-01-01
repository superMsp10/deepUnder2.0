using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
		protected CameraManeger thisCam;
		public bool visible;
		public Vector2 dir;
		public float stage;
		public  playLevel thisLevel;
		public gameManager thisManage;
		public bool paused = false;
		private Vector2 camPos;


		void Awake ()
		{
				thisLevel.addController (this);

		}
	
		void Start ()
		{
				thisManage = gameManager.thisM;
				thisCam = thisManage.thisCamManange;
				thisLevel = (playLevel)thisLevel;

		}
			
		void Update ()
		{
				camPos = thisCam.cameraPos;
				if (Vector2.Distance (transform.position, camPos))
						Debug.Log ("hi");

		}


		public void changeS (float  lev)
		{
				thisLevel = (playLevel)thisLevel;
				thisCam = thisManage.thisCamManange;
				if (lev == stage) {

						gameObject.SetActive (true);
						thisLevel.addToStage (this);
				} else {
						gameObject.SetActive (false);
						thisLevel.removeFromStage (this);
				}

		}
		void OnApplicationFocus (bool focusStatus)
		{
		
				paused = ! focusStatus;
		}
		

}

