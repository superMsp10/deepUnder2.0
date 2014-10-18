using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour
{
	 
		public GameObject[] choices;
		public GameObject[] thisParts;
		public int multi;
		public float tiltAngle = 0.0F;
		public bool randomRot = false;
		public bool addRandomRot = false;
		public int maxRot;
		public int minRot;
		public float offsetX = 0.0F;
		public float offsety = 0.0F;
		public bool rXOffset = false;
		public bool addRandomXOff = false;
		public float maxXOff;
		public float minXOff;
		public bool rYOffset = false;
		public bool addRandomYOff = false;
		public float maxYOff;
		public float minYOff;
		Quaternion rot;

		public void growTree ()
		{
				
				
				multi = Random.Range (1, multi);
				thisParts = new GameObject[multi];
				if (choices.Length > 0) {

						for (int i = 0; i < multi; i++) {
								float angle = tiltAngle;
								if (randomRot) {
										if (addRandomRot)
												angle += Random.Range (minRot, maxRot);
										else
												angle = Random.Range (minRot, maxRot);
								
								}
								float x = offsetX;
								float y = offsety;
								if (rXOffset) {

										if (addRandomXOff) {
												x += Random.Range (minXOff, maxXOff);
											

										} else {
												x = Random.Range (minXOff, maxXOff);
												


										}

								}

								if (rYOffset) {
					
										if (addRandomYOff) {
												y += Random.Range (minYOff, maxYOff);
						

										} else {
												y = Random.Range (minYOff, maxYOff);
						
						
						
										}
					
								}
				
				
								Vector3 pos = new Vector3 (transform.position.x + x, transform.position.y + y);
								rot = Quaternion.Euler (0, 0, angle);
								GameObject thisChoice = choices [Random.Range (0, choices.Length)];
								thisParts.SetValue (Instantiate (thisChoice, pos, rot), i);

						}
				} else
						Debug.LogError ("no choices for tree parts");

		}
}
