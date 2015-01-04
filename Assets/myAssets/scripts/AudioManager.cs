using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
		public static AudioManager thisAM;
		private gameManager thisManage;
		public  AudioSource bMusic;
		public  AudioSource buttonFX;

		public Slider[] backgroundMusicSliders;
		public Slider[] buttonFXSliders;

		void Awake ()
		{
				if (thisAM == null)
						thisAM = this;


		}
		
		void Start ()
		{
				bMusic.volume = PlayerPrefs.GetFloat ("BackgroundMusic");
				buttonFX.volume = PlayerPrefs.GetFloat ("buttonFX");

				foreach (Slider s in backgroundMusicSliders) {
						s.value = bMusic.volume;
				}
				foreach (Slider s in buttonFXSliders) {
						s.value = buttonFX.volume;
				}
				buttonFX.enabled = true;
		}
	
		
		void Update ()
		{
		}

		void OnDestroy ()
		{
				PlayerPrefs.SetFloat ("BackgroundMusic", bMusic.volume);
				PlayerPrefs.SetFloat ("buttonFX", buttonFX.volume);

		}

		public static void AAA ()
		{

		}
	

}
