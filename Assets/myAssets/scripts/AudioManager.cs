using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
		private float BMV;
		private float fxVolume;
		public gameManager thisManage;
		public float defaultVolume = 1;
		public List<Slider> bmvSliders;
		public List<Slider> fxSliders;

		


		// Use this for initialization
		void Start ()
		{
				BMV = PlayerPrefs.GetFloat ("BMV", defaultVolume);
				changeBMV (BMV);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		public void playSound (Vector3 pos, string category, AudioClip clip)
		{
				float v = 0;
				if (category == "b")
						v = BMV;
				else
						Debug.LogError ("No matching category for your audio");
				//else if (category == "s")
				//v = EnemyS;
				AudioSource.PlayClipAtPoint (clip, pos, v);
		
		}

		public void changeBMV (float volume)
		{
				
				BMV = volume;
				foreach (level l in thisManage.levels) {

						l.audio.volume = BMV;
				}
				foreach (Slider s in sliderUI) {
			
						s.value = volume;
				}
			



		}

		public float getBMV ()
		{

				return BMV;
		}
			
		void OnDestroy ()
		{
				PlayerPrefs.SetFloat ("BMV", BMV);

		}
}
