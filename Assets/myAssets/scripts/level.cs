using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level : MonoBehaviour
{
		public GameObject camera1;
		public bool spawnable = true;
		public int votes;
		public Material skybox;
		public List<Entity> entities;
		public AudioManager audioM;


		// Use this for initialization
		void Start ()
		{
			
		}
			
		void OnEnable ()
		{

				audio.volume = audioM.getBMV ();	
				
				


		}


		// Update is called once per frame
		public void addEntity (Entity e)
		{

				e.gameObject.transform.parent = transform.FindChild ("Entities");
				entities.Add (e);


		}

		public void removeEntity (Entity e)
		{
				entities.Remove (e);

		
		
		}

		void Update ()
		{
	
		}

		public void clearAllEntities ()
		{
		
				foreach (Entity e in entities) {
						e.DestroyEntity (0);


				}
		
		}
}

