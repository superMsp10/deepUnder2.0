using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour
{
	 
		public GameObject[] choices;
		public GameObject[] thisParts;
		public int multi;
		public float smooth = 2.0F;
		public float tiltAngle = 30.0F;
		//public int xMax;
		//public int yMax;
		public int maxRot;
		Quaternion rot;

		public void growTree ()
		{
				if (choices.Length > 0) {
						multi += Random.Range (2, multi);
						for (int i = 0; i < multi; i++) {
								GameObject thisChoice = choices [Random.Range (0, choices.Length)];
								Vector3 pos = new Vector3 (transform.position.x, transform.position.y);
								rot = Quaternion.Euler (0, 0, 10);
								Instantiate (thisChoice, pos, rot);
						}
				} else
						Debug.LogError ("no choices for tree parts");

		}
}
