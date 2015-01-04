using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{

		// Use this for initialization
		private AudioManager thisAM;
		public AudioSource channel;
		public AudioClip thisClip;


		void Start ()
		{
				thisAM = AudioManager.thisAM;
				channel = thisAM.buttonFX;
		}
			
		void OnEnable ()
		{
				
				channel.PlayOneShot (thisClip);
		}

		void OnDisable ()
		{
		
				//channel.enabled = false;
		}


	
}
