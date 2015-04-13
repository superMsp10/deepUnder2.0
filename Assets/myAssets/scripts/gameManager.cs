
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{


		public static gameManager thisM;
		public CameraManeger thisCamManange;
		public invManager thisInv;
		public bool paused = true;
		public level currentLevel;
		protected level start;
		public level[] levels;
		public bool dead = false;
		public bool loadDefault = false;
		public level defaultLev;
		public Camera currCamera;
		public GameObject myPlayerIns;
		public GameObject myPlayer;
		private SpawnSpot[] SS;
		private SpawnSpot MySS;
		public GameObject gameUI;
		public GameObject pausedUi;
		public GameObject deathScreen;
		public Text score;
		public Text pre_score;
		public bool resetScore;
		public bool storyEnd;
		public level end;
		int lvlPassed = 0;
		int died;
		public Holdable currency;
		float surviveTime;

		void Awake ()
		{
				if (thisM == null) {
						thisM = this;
				}
		}

		void Start ()
		{		

				if (resetScore) {
						PlayerPrefs.DeleteAll ();
				}
//				PhotonNetwork.player.name = PlayerPrefs.GetString ("UserName", "EnterNameHere");
				levels = FindObjectsOfType<level> ();
				foreach (level l in levels) {
						l.gameObject.SetActive (false);
				}
				if (defaultLev != null && loadDefault)
						levelex (defaultLev);
				else
						changeLvl ("startMenu");
				thisInv = invManager.thisInv;
				pre_score.text = PlayerPrefs.GetInt ("highScore", 0).ToString ();

		}

		public void restartLevel ()
		{
				Application.LoadLevel (Application.loadedLevel);
		}

		public void Update ()
		{

				if (!currentLevel.menuLevel) {
						
						if (dead && deathScreen.activeSelf == false) {

								menuReset ();
								deathScreen.SetActive (true);
			
						} else if (Input.GetKeyDown (KeyCode.Escape) && !dead) {
								paused = ! paused;
								changeMenu ();
						}
								
				}
		}

		public void setPaused ()
		{
				paused = !paused;
				changeMenu ();

		}

		public void changeMenu ()
		{
				if (paused && gameUI.activeSelf == false) {
						pausedUi.SetActive (false);
						deathScreen.SetActive (false);
						gameUI.SetActive (true);
				}
				if (!paused && pausedUi.activeSelf == false) {
						gameUI.SetActive (false);
						pausedUi.SetActive (true);
						deathScreen.SetActive (false);
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
				died += 1;
				surviveTime = Time.time - surviveTime;
				if (currentLevel.calScore)
						setScore ();
				if (myPlayer != null) {
						Destroy (myPlayer);
				}
				dead = true;
				if (currentLevel != null) {
						currentLevel.camera1.SetActive (true);
						

				}

				paused = false;
				thisInv.clearInv ();
				

		}


		

		

		public void spawn ()
		{
				surviveTime = Time.time;
				SS = FindObjectsOfType<SpawnSpot> ();

				currentLevel.camera1.SetActive (false);
				paused = true;
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
				paused = true;
				changeMenu ();
				(currentLevel as playLevel).changeStage (1);


		}

		public void transferLevelPlayer ()
		{
				currentLevel.camera1.SetActive (false);
				paused = true;
				changeMenu ();
				myPlayer.GetComponent<Mob1> ().changeLevel (currentLevel);
				SS = FindObjectsOfType<SpawnSpot> ();

				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer.transform.position = MySS.transform.position;
				lvlPassed += 1;


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
				//	menuReset ();
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
						die ();
				if (currentLevel.spawnable) {
						spawn ();
						
				}
				currentLevel.startLevel ();
				
				
		}

		void setScore ()
		{
				int gold = 100000 - thisInv.takeItem (currency, 100000);

				int deathPass = lvlPassed * 100 / died;
			
				int sclaeSurvivalTime = (int)surviveTime / 5;
				int score_ = (sclaeSurvivalTime + gold) * deathPass;
				score.text = score_.ToString ();
				if (int.Parse (pre_score.text) < score_)
						pre_score.text = score_.ToString ();

		}
		
		void OnDestroy ()
		{
				PlayerPrefs.SetInt ("highScore", int.Parse (pre_score.text));

		}
		
}