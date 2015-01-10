
using UnityEngine;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{


		public static gameManager thisM;
		public CameraManeger thisCamManange;
		public bool inGame = false;
		public level currentLevel;
		protected level start;
		public level[] levels;
		public bool dead = false;
		public bool loadDefault = false;
		public Camera currCamera;
		public GameObject ins1;
		public GameObject ins2;

		private string version;
		public GameObject myPlayerIns;
		public GameObject myPlayer;
		private SpawnSpot[] SS;
		private SpawnSpot MySS;
		private bool connecting = false;
		List <string> chatMessages;
		int MaxChatMess = 5;
		private string code = "";
		private string status = "[newbie]";
		private health myHp;
		void Awake ()
		{
				if (thisM == null) {
						thisM = this;
				}
		}
		void Start ()
		{		
				version = "NetTest 0.2.2";
//				PhotonNetwork.player.name = PlayerPrefs.GetString ("UserName", "EnterNameHere");
				levels = FindObjectsOfType<level> ();
				foreach (level l in levels) {
						l.gameObject.SetActive (false);
				}
				if (currentLevel != null && loadDefault)
						levelex (currentLevel);
				else
						changeLvl ("startMenu");

				inGame = false;
		}
	
		void Update ()
		{
				/*if (myPlayer != null) {
						Vector2 spawnPoint = new Vector2 (myPlayer.transform.position.x + 10, myPlayer.transform.position.y + 10);
						if (Input.GetKeyDown (KeyCode.Escape)) {
								inGame = !inGame;
						}
						if (Input.GetKeyDown (KeyCode.Mouse0)) {
								GameObject g = (GameObject)Instantiate (ins1, spawnPoint, Quaternion.identity);
								g.transform.parent = null;
								Entity e = g.GetComponent<Entity> ();
								e.thisLevel = currentLevel;
						}
						if (Input.GetKeyDown (KeyCode.Mouse1)) {
								GameObject g = (GameObject)Instantiate (ins2, spawnPoint, Quaternion.identity);
								g.transform.parent = null;

								Entity e = g.GetComponent<Entity> ();
								e.thisLevel = currentLevel;
						}
				}*/
		}

		public void spawn ()
		{
				currentLevel.camera1.SetActive (false);
				inGame = true;
				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer = (GameObject)Instantiate
			(myPlayerIns, MySS.transform.position, MySS.transform.rotation);
				myPlayer.SetActive (true);
				currCamera = myPlayer.GetComponentInChildren<Camera> ();
				myHp = myPlayer.GetComponent<health> ();
				thisCamManange = myPlayer.GetComponentInChildren<CameraManeger> ();
				Entity e = myPlayer.GetComponent<Entity> ();
				if (e == null)
						Debug.LogError ("cannot spawn not a entity");
				else
						e.thisLevel = currentLevel;
		}

		public void changeLvl (int i)
		{
				levelex (levels [i]);
			
		}

		public void changeLvl (string i)
		{
				foreach (level l in levels) {
						if (l.name == i) {
								levelex (l);
								
						}
				}
		}

		public void levelex (level lev)
		{
				//voted = false;
				if (currentLevel != null) {
						currentLevel.gameObject.SetActive (false);
						currentLevel.endLevel ();
				}
				
				currentLevel = lev;
				currentLevel.gameObject.SetActive (true);
				currentLevel.camera1.SetActive (true);
				currCamera = currentLevel.camera1.camera;
				RenderSettings.skybox = currentLevel.skybox;

				if (currentLevel.spawnable) {
						dead = true;
						SS = FindObjectsOfType<SpawnSpot> ();
						spawn ();
						
				}
				currentLevel.startLevel ();
				
				
		}
		
		
}