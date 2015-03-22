using UnityEngine;
using System.Collections;

public class Dummy : Enemy
{

		void Start ()
		{
		
				thisManage = gameManager.thisM;
				checkNecesseries ();
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				thisAttributes.maxSped = Random.Range (5, 15);		
				thisAttributes.moveForce = Random.Range (1, 5);		
				thisAttributes.jump = Random.Range (200, 600) + 100;		
				thisAttributes.optTargetRange = Random.Range (1, 30);		
		}


		
	
}
