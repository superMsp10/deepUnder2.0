using UnityEngine;
using System.Collections.Generic;

public class playLevel : level
{
		public float stage = 0;
		public List<CameraController> visible;
		public List<CameraController> cC;

		void Start ()
		{
				thisManage = gameManager.thisM;
				audioM = AudioManager.thisAM;
				changeStage (1.0f);
		}

		public void changeStage (float l)
		{
				foreach (CameraController c in visible) {

				}
		}
	
		public void addController (CameraController cam)
		{
				cC.Add (cam);
		
		}
	
		public void removeController (CameraController cam)
		{
				cC.Remove (cam);
		
		}
}
