using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour
{
	 
		public GameObject[] choices;
		public GameObject thisPart;
		public int rotation;
		public bool autoRotate;

		public void growTree ()
		{
				if (autoRotate) {
						rotation = Random.Range (0, 360);
				}
			
				if (choices.Length > 0) {
						thisPart = choices [Random.Range (0, choices.Length)];
						Instantiate (thisPart, transform.position, Quaternion.identity);
						transform.rotation.Set (0, 0, rotation, 0); 
						
				} else
						Debug.Log ("no cjoices available");
			
		}
	
	
}
