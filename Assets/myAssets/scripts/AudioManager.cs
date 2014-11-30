using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
		private float BMV;
		public gameManager thisManage;
		public float defaultVolume = 1;
		


		// Use this for initialization
		void Start ()
		{
				BMV = defaultVolume;
				changeBMV (defaultVolume);
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



		}

		public float getBMV ()
		{

				return BMV;
		}
}
