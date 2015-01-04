using UnityEngine;
using System.Collections;

public class Dummy : Enemy
{

		
		// Update is called once per frame
		void FixedUpdate ()
		{

				checkGround ();
				TargetSight ();
		}
	
		
	
}
