using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour
{
	 
		public GameObject[] choices;
		public GameObject[] thisParts;
		public int multi;
		public float tiltAngle = 30.0F;
		public bool randomRot = false;
		public int maxRot;
		Quaternion rot;

		public void growTree ()
		{
				
				
				multi = Random.Range (1, multi);
				thisParts = new GameObject[multi];
				if (choices.Length > 0) {

						for (int i = 0; i < multi; i++) {

								if (randomRot) {
										tiltAngle += Random.Range (tiltAngle, maxRot);
								}

								Vector3 pos = new Vector3 (transform.position.x, transform.position.y);
								rot = Quaternion.Euler (0, 0, tiltAngle);
								GameObject thisChoice = choices [Random.Range (0, choices.Length)];
								thisParts.SetValue (Instantiate (thisChoice, pos, rot), i);

						}
				} else
						Debug.LogError ("no choices for tree parts");

		}
}
