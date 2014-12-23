using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tihs : level
{
		public override  void startLevel ()
		{
		
				//thisSound.enabled = true;
				thisManage.spawn ();

		
		}
	
		public  override void endLevel ()
		{
		
				thisSound.enabled = false;
		
		}
}

