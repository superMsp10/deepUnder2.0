using UnityEngine;
using System.Collections;

public class NPC : Mob
{
		public bool blab;
		public string greeting1 = "Hello";
		public TextMesh thisText;

		void Start ()
		{
				thisText = GetComponentInChildren<TextMesh> ();
				if (thisText == null) {
						Debug.LogError ("no text mesh included in NPC");
				} else if (blab) {
						thisText.text = greeting1;
				} else {
						thisText.text = "";
				}
	
		}

		void Update ()
		{
	
		}

		public void OnTriggerEnter2D ()
		{
				Debug.Log ("hi");
				if (!blab)
						thisText.text = greeting1;
		}


}
