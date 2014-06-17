using UnityEngine;
using System.Collections;

public class NPC : Mob
{
		public bool blab;
		public string greeting1 = "Hello";


		void Start ()
		{	
			
	
		}

		void Update ()
		{
	
		}

		public void OnTriggerEnter2D (Collider2D other)
		{
				if(other.name=="player")Debug.Log ("hi");
			
		}


}
