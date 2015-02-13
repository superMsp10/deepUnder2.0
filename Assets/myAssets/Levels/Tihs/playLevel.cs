using UnityEngine;
using System.Collections.Generic;

public class playLevel : level
{
		public float stage = 0;
		public List<CameraController> stageBoundires;
		public List<CameraController> xVisible;
		public List<CameraController> yVisible;

		public List<CameraController> allBoundries;
		protected CameraManeger thisCam;

		

		public override  void startLevel ()
		{
				thisManage = gameManager.thisM;
				thisCam = thisManage.thisCamManange;
				audioM = AudioManager.thisAM;
				thisCam = thisManage.thisCamManange;
				changeStage (stage);
				thisChannel.clip = startMusic;
				thisChannel.Play ();

		}
	
		public  override void endLevel ()
		{
		

		}

		public void changeStage (float l)
		{
				stage = l;
				foreach (CameraController c in allBoundries) {
						c.changeS (l);
				}
				foreach (Entity e in entities) {

						e.changeS (l);
				}
		}
	
		public void addController (CameraController cam)
		{
				allBoundries.Add (cam);
		
		}
	
		public void removeController (CameraController cam)
		{
				allBoundries.Remove (cam);
		
		}

		public void addToStage (CameraController cam)
		{
				stageBoundires.Add (cam);
		
		}
	
		public void removeFromStage (CameraController cam)
		{
				stageBoundires.Remove (cam);
		
		}
}
