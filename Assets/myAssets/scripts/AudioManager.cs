using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
		public static AudioManager thisAM;
		private gameManager thisManage;
		public  AudioSource bMusic;
		public  AudioSource buttonFX;
		public  AudioSource playerFX;
		public  AudioSource weapons;


		public Slider[] backgroundMusicSliders;
		public Slider[] buttonFXSliders;
		public Slider[] playerFXSliders;
		public Slider[] weaponSliders;


		void Awake ()
		{
				if (thisAM == null)
						thisAM = this;


		}
		
		void Start ()
		{
				bMusic.volume = PlayerPrefs.GetFloat ("BackgroundMusic", 0.1f);
				buttonFX.volume = PlayerPrefs.GetFloat ("buttonFX", 0.2f);
				playerFX.volume = PlayerPrefs.GetFloat ("playerFX", 0.3f);
				weapons.volume = PlayerPrefs.GetFloat ("weaponFX", 0.2f);
				

				foreach (Slider s in backgroundMusicSliders) {
						s.value = bMusic.volume;
				}
				foreach (Slider s in buttonFXSliders) {
						s.value = buttonFX.volume;
				}

				foreach (Slider s in playerFXSliders) {
						s.value = playerFX.volume;
				}
				foreach (Slider s in weaponSliders) {
						s.value = weapons.volume;
				}
				buttonFX.enabled = true;
		}
	
		public void updateSliders ()
		{
				foreach (Slider s in backgroundMusicSliders) {
						s.value = bMusic.volume;
				}
				foreach (Slider s in buttonFXSliders) {
						s.value = buttonFX.volume;
				}
		
				foreach (Slider s in playerFXSliders) {
						s.value = playerFX.volume;
				}
				foreach (Slider s in weaponSliders) {
						s.value = weapons.volume;
				}
		}
		

		void OnDestroy ()
		{
				PlayerPrefs.SetFloat ("BackgroundMusic", bMusic.volume);
				PlayerPrefs.SetFloat ("buttonFX", buttonFX.volume);
				PlayerPrefs.SetFloat ("playerFX", playerFX.volume);
				PlayerPrefs.SetFloat ("weaponFX", weapons.volume);
		}

		

}
