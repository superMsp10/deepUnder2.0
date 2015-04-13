using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public  class level : MonoBehaviour
{
		public GameObject camera1;
		public bool spawnable = true;
		public int votes;
		public Material skybox;
		public List<Entity> entities;
		protected AudioManager audioM;
		protected gameManager thisManage;
		public AudioClip startMusic;
		public AudioSource thisChannel;
		public int deathHeight = -200;
		public bool killPlayerOnEnter = false;
		public bool menuLevel = false;
		public bool calScore = true;


		// Use this for initialization
		void Start ()
		{
				thisManage = gameManager.thisM;
				audioM = AudioManager.thisAM;
		}
			

		public virtual  void startLevel ()
		{
				thisChannel.clip = startMusic;
				thisChannel.Play ();

		}

		public  virtual void endLevel ()
		{
		

		}



		public void addEntity (Entity e)
		{
				if (!e.customHierarchy) {
		
						e.gameObject.transform.parent = transform.FindChild ("Entities");
				}

				entities.Add (e);


		}

		public void removeEntity (Entity e)
		{
				entities.Remove (e);

		
		
		}

		

		public void clearAllEntities ()
		{
		
				foreach (Entity e in entities) {
						e.DestroyEntity (0);


				}
		
		}
}

