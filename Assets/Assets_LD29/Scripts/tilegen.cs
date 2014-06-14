using UnityEngine;
using System.Collections;

public class tilegen : MonoBehaviour {

	// Use this for initialization
	Vector3 position;
	public Object obj;

	void Start () {
		position = new Vector3 (0,0,0);
		for(int i = 0 ; i < 15; i++){
			position.x = i * 4;
			Instantiate (obj,position,Quaternion.identity);
			
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
