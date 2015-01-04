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
				thisAttributes.flyAmount = Random.Range (0.01f, 0.5f);		
				thisAttributes.moveForce = Random.Range (1, 5);		
				thisAttributes.jump = Random.Range (300, 500);		
				thisAttributes.optTargetRange = Random.Range (1, 30);		
		}

		// Update is called once per frame
		void FixedUpdate ()
		{

				checkGround ();
				TargetSight ();
		}
	
		
	
}
