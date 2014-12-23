using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tihs : level
{
		public override  void startLevel ()
		{
		
				//thisSound.enabled = true;
				Debug.Log ("Hi, from tihs");
				thisManage.spawn ();

		
		}
	
		public  override void endLevel ()
		{
		
				thisSound.enabled = false;
		
		}
}

