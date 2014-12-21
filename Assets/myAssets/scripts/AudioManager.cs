using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
		



		public static AudioManager thisAM;
		private float BMV;
		private float fxVolume;
		private gameManager thisManage;
		public float defaultVolume = 1;
		public List<Slider> bmvSliders;
		public List<Slider> fxSliders;
		public int maxPlay = 10;
		public List<AudioSource> playing;

		void Awake ()
		{
				if (thisAM == null)
						thisAM = this;


		}
		// Use this for initialization
		void Start ()
		{
				thisManage = gameManager.thisM;
				BMV = PlayerPrefs.GetFloat ("BMV", defaultVolume);
				fxVolume = PlayerPrefs.GetFloat ("FXV", defaultVolume);

				changeBMV (BMV);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		public  void playSound (Vector3 pos, string category, AudioClip clip)
		{
				float v = 0;
				if (category == "b")
						v = BMV;
				if (category == "fx")
						v = fxVolume;
				else
						Debug.LogError ("No matching category for your audio");
				//else if (category == "s")
				//v = EnemyS;
				AudioSource.PlayClipAtPoint (clip, pos, v);
		
		}

		public void changeBMV (float volume)
		{
				
				BMV = volume;
				
				if (thisManage == null) {
						Debug.LogError ("NO manager ");
				} else {
						foreach (level l in thisManage.levels) {

								l.audio.volume = BMV;
						}
						foreach (Slider s in bmvSliders) {
			
								s.value = volume;
						}
			

				}

		}

		public float getBMV ()
		{

				return BMV;
		}
			
		public void changeFXV (float volume)
		{
		
				fxVolume = volume;
				
				foreach (Slider s in fxSliders) {
			
						s.value = volume;
				}
		
		
		
		
		}
	
		public float getFXV ()
		{
		
				return fxVolume;
		}
			
		void OnDestroy ()
		{
				PlayerPrefs.SetFloat ("BMV", BMV);
				PlayerPrefs.SetFloat ("FXV", fxVolume);

		}
}
