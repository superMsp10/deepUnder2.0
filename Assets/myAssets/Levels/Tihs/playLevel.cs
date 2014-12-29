﻿using UnityEngine;
using System.Collections.Generic;

public class playLevel : level
{
		public float stage = 0;
		public List<CameraController> stageBoundires;
		public List<CameraController> allBoundries;
		public  CameraManeger thisCam;

		void Start ()
		{
				thisManage = gameManager.thisM;
				audioM = AudioManager.thisAM;
				thisCam = thisManage.thisCam;
		}
		
		public override  void startLevel ()
		{
				thisCam.addPlayer (thisManage.currCamera);
				changeStage (1);
		}
	
		public  override void endLevel ()
		{
		
				thisSound.enabled = false;
		
		}

		public void changeStage (float l)
		{
				stage = l;
				foreach (CameraController c in allBoundries) {
						c.changeS (l);
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
