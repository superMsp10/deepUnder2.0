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


		void Awake ()
		{
				thisLevel.addController (this);

		}
	
		void Start ()
		{
				thisCam = CameraManeger.thisCamera;
				thisManage = gameManager.thisM;
				thisLevel = (playLevel)thisLevel;

		}

		public void changeS (float  lev)
		{
				if (lev == stage) {

						gameObject.SetActive (true);
						thisLevel.addToStage (this);
				} else {
						gameObject.SetActive (false);
						thisLevel.removeFromStage (this);
				}

		}

		

}

