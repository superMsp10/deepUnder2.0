﻿using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{
		public GameObject camera1;
		public bool spawnable = true;
		public int votes;
		// Use this for initialization
		void Start ()
		{
				if (spawnable) {
						GameObject[] Trees = GameObject.FindGameObjectsWithTag ("treePart");
						foreach (GameObject i in Trees) {
								i.GetComponent<tree> ().growTree ();
						}
				}
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
}
