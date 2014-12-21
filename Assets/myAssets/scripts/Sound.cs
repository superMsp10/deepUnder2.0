using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{

		// Use this for initialization
		private AudioManager thisAM;
		public AudioSource thisS;
		public AudioClip thisClip;

		void Start ()
		{
				thisAM = AudioManager.thisAM;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void playSound ()
		{
				thisS.volume = thisAM.getFXV ();

		}


	
}
