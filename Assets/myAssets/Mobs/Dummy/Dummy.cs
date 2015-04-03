﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dummy : Enemy
{

		public string[] dialog;

		void Start ()
		{
		
				thisManage = gameManager.thisM;
				checkNecesseries ();
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				InvokeRepeating ("updateDialog", 0, 5f);
		
		}
		public override  void die ()
		{
				Resource r = GetComponent<Resource> ();
				r.dropMadeOf ();
				Destroy (gameObject);

		}

		void updateDialog ()
		{
				GetComponent<textFade> ().responses.GetComponent<Text> ().text = dialog [Random.Range (0, dialog.Length)];

		}

		
	
}
