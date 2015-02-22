
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
		public level defaultLev;
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
		private string status = "[newbie]";
		public GameObject gameUI;
		public GameObject pausedUi;
		public GameObject deathScreen;

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
				if (defaultLev != null && loadDefault)
						levelex (defaultLev);
				else
						changeLvl ("startMenu");

		}

		public void restartLevel ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}

		public void Update ()
		{
				if (!currentLevel.menuLevel) {
						if (Input.GetKeyDown (KeyCode.Escape))
								inGame = ! inGame;
						changeMenu ();
				}
		}

		public void changeMenu ()
		{
				if (inGame && gameUI.activeSelf == false) {
						pausedUi.SetActive (false);
						deathScreen.SetActive (false);
						gameUI.SetActive (true);
				}
				if (!inGame && pausedUi.activeSelf == false) {
						gameUI.SetActive (false);
						pausedUi.SetActive (true);
						deathScreen.SetActive (false);
				}
				if (dead && deathScreen.activeSelf == false) {
						gameUI.SetActive (false);
						pausedUi.SetActive (false);
						deathScreen.SetActive (true);

				}
		}

		public void menuReset ()
		{
				gameUI.SetActive (false);
				pausedUi.SetActive (false);
				deathScreen.SetActive (false);

		}

		public void die ()
		{

				if (myPlayer != null) {
						Destroy (myPlayer);
				}
				dead = true;
				currentLevel.camera1.SetActive (true);
				inGame = false;


		}

		public void spawn ()
		{
				SS = FindObjectsOfType<SpawnSpot> ();

				currentLevel.camera1.SetActive (false);
				inGame = true;
				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer = (GameObject)Instantiate
			(myPlayerIns, MySS.transform.position, MySS.transform.rotation);
				myPlayer.SetActive (true);
				currCamera = myPlayer.GetComponentInChildren<Camera> ();
				thisCamManange = myPlayer.GetComponentInChildren<CameraManeger> ();
				Entity e = myPlayer.GetComponent<Entity> ();
				if (e == null)
						Debug.LogError ("cannot spawn not a entity");
				else
						e.thisLevel = currentLevel;
				dead = false;
		}

		public void transferLevelPlayer ()
		{
				currentLevel.camera1.SetActive (false);
				inGame = true;
				myPlayer.GetComponent<Mob1> ().changeLevel (currentLevel);
				SS = FindObjectsOfType<SpawnSpot> ();

				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer.transform.position = MySS.transform.position;

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
				menuReset ();
				if (currentLevel != null) {
						currentLevel.gameObject.SetActive (false);
						
						currentLevel.endLevel ();
					
				}
				currentLevel = lev;
				AudioManager.thisAM.updateSliders ();
				currentLevel.gameObject.SetActive (true);
				currentLevel.camera1.SetActive (true);
				currCamera = currentLevel.camera1.camera;
				RenderSettings.skybox = currentLevel.skybox;
				if (currentLevel.killPlayerOnEnter && myPlayer != null)
						Destroy (myPlayer);
				if (currentLevel.spawnable) {
						spawn ();
						
				}
				currentLevel.startLevel ();
				
				
		}
		
		
}