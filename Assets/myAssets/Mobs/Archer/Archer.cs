﻿using UnityEngine;
using System.Collections;

public class Archer : Enemy
{


		void Start ()
		{
	
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				checkNecesseries ();
	
		}


		protected override void checkNecesseries ()
		{
		
				if (thisLevel == null)
						Debug.LogError ("no Level referenced for this entity: " + gameObject.name);
		
				if (thisAnim == null && animated) {
						Debug.LogError ("no animator is provided");
				}
				if (groundCheck == null)
						Debug.Log ("no feets included");
				bodyParts = GetComponentsInChildren<BodyPart> ();
				foreach (BodyPart b in bodyParts) {
						b.thisLevel = thisLevel;
				}
				healthbar.maxValue = thisAttributes.maxHP;
				healthbar.value = thisAttributes.HP;
		
		}

}
