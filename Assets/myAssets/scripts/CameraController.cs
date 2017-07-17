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
		public bool yAxis = false;
		bool addedToStage = false;

		void Awake ()
		{
				thisLevel.addController (this);
				addedToStage = false;

		}
	
		void Start ()
		{
				thisManage = gameManager.thisM;
				thisCam = thisManage.thisCamManange;
				if (dir.y != 0) {
						yAxis = true;
				} else {

						yAxis = false;
				}
		}
			
		void Update ()
		{
				checkVisible ();
				
		}

		public void checkVisible ()
		{

				if (yAxis) {
						if (GetComponent<Renderer>().isVisible && !visible) {
								visible = true;
								thisLevel.yVisible.Add (this);
						} else if (!GetComponent<Renderer>().isVisible) {
								visible = false;
								thisLevel.yVisible.Remove (this);
						}
				}
				if (!yAxis) { 
						if (GetComponent<Renderer>().isVisible && !visible) {
								visible = true;
								thisLevel.xVisible.Add (this);
						} else if (!GetComponent<Renderer>().isVisible) {
								visible = false;
								thisLevel.xVisible.Remove (this);
						}
				}
		}

		public void changeS (float  lev)
		{

				if (lev == stage && !addedToStage) {
						addedToStage = true;
						gameObject.SetActive (true);
						thisLevel.addToStage (this);
				} else {
						addedToStage = false;
						gameObject.SetActive (false);
						thisLevel.removeFromStage (this);
				}
				checkVisible ();

		}

		void OnApplicationFocus (bool focusStatus)
		{
		
				paused = ! focusStatus;
		}
		

}

