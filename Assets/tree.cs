using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour {
	 
	public GameObject[] choices;
	GameObject thisPart;

	public void growTree () {

		if (choices.Length >0) {
			thisPart = choices [Random.Range (0,choices.Length)];
		} else
			Debug.Log ("no cjoices available");
		Instantiate (thisPart,transform.position,Quaternion.identity);
	}
	
	
}
