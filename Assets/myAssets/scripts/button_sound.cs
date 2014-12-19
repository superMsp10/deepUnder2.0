using UnityEngine;
using System.Collections;



public class button_sound : MonoBehaviour
{

		// Use this for initialization
		public AudioManager thisAM;
		public AudioClip thisClip;
		public bool played;


		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void playSound ()
		{
				if (!played) {
						thisAM.playSound (transform.position, "fx", thisClip);	
						played = true;
						Debug.Log ("hi");

				}
		}
}
