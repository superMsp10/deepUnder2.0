﻿
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

		public bool resetPrefs;
		public Camera currCamera;
		public GameObject myPlayerIns;
		public GameObject myPlayer;
		private SpawnSpot[] SS;
		private SpawnSpot MySS;
		public GameObject gameUI;
		public GameObject pausedUi;
		public GameObject deathScreen;
		public Text score;
		public Text diedAmount;

		public Text pauseScore;
		public Text pre_score;
		public bool storyEnd;
		public level end;
		public bool deathEnd;
		int died;
		public Holdable currency;
		float surviveTime;
		float spawnTime;

		//DEV CONSOLE//
		public bool showDevCon;
		public GameObject devConsoleButton;
		public Text levelChangeString;
		public Text giveGoldAmount;
		public Text giveHealthAmount;


		//-----------------------------------------Mono-----Methods-----------------------------------------\\
		void Awake ()
		{
				if (thisM == null) {
						thisM = this;
				}
		}

		void Start ()
		{		

				if (resetPrefs) {
						PlayerPrefs.DeleteAll ();
						changeCamSize (40);
				}
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
				if (showDevCon)
						devConsoleButton.SetActive (true);
		}

		public void Update ()
		{
		
				if (!currentLevel.menuLevel) {
			
						if (dead && deathScreen.activeSelf == false) {
								if (deathEnd) {
										levelex (end);
								}
								menuReset ();
								deathScreen.SetActive (true);
				
						} else if (Input.GetKeyDown (KeyCode.Escape) && !dead) {
								paused = ! paused;
								changeMenu ();
						}
			
				}
		}


		void OnDestroy ()
		{
				PlayerPrefs.SetInt ("highScore", int.Parse (pre_score.text));
		
		}


		//--------------------------------MY---------UI-----Methods-----------------------------------------\\




		
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
						if (currentLevel.calScore)
								setScore ();
				}
				
		}

		public void menuReset ()
		{
				gameUI.SetActive (false);
				pausedUi.SetActive (false);
				deathScreen.SetActive (false);

		}

		//--------------------------------MY---------Player-----Methods-----------------------------------------\\


		public void die ()
		{

				died ++;
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
				spawnTime = Time.time;

				SS = FindObjectsOfType<SpawnSpot> ();

				currentLevel.camera1.SetActive (false);
				paused = true;
				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer = (GameObject)Instantiate
			(myPlayerIns, MySS.transform.position, MySS.transform.rotation);
				myPlayer.SetActive (true);
				thisCamManange = myPlayer.GetComponentInChildren<CameraManeger> ();
				currCamera = thisCamManange.playerCamera;
		

				Entity e = myPlayer.GetComponent<Entity> ();
				if (e == null)
						Debug.LogError ("cannot spawn not a entity");
				else
						e.thisLevel = currentLevel;
				dead = false;
				paused = true;
				changeMenu ();


		}

		public void transferLevelPlayer ()
		{

				paused = true;
				currCamera = thisCamManange.playerCamera;

				currCamera.gameObject.SetActive (true);

				changeMenu ();
				myPlayer.GetComponent<Mob1> ().changeLevel (currentLevel);
				SS = FindObjectsOfType<SpawnSpot> ();

				MySS = SS [Random.Range (0, SS.Length)];
				myPlayer.transform.position = MySS.transform.position;
			


		}

		void setScore ()
		{
				surviveTime = Time.time - spawnTime;
		
		
				int gold = 100000 - thisInv.takeItem (currency, 100000);
		
				int sclaeSurvivalTime = (int)surviveTime / 20;
				int score_ = (sclaeSurvivalTime + gold);
				diedAmount.text = died.ToString ();
		
				score.text = score_.ToString ();
				pauseScore.text = score_.ToString ();
		
				if (int.Parse (pre_score.text) < score_)
						pre_score.text = score_.ToString ();
		
		}
	
		public void changeCamSize (float f)
		{
				myPlayerIns.GetComponent<Tarsc> ().cameraM.playerCamera.orthographicSize = f;
		
		
		}
	
	
	
		public void changeCamera ()
		{
				if (currCamera == thisCamManange.playerCamera) {
						thisCamManange.playerCamera.gameObject.SetActive (false);
						currentLevel.camera1.SetActive (true);
						currCamera = currentLevel.camera1.camera;
				} else {
						thisCamManange.playerCamera.gameObject.SetActive (true);
						currentLevel.camera1.SetActive (false);
						currCamera = thisCamManange.playerCamera;
			
			
				}
		
		
		}


		//--------------------------------MY---------Level-----Methods-----------------------------------------\\


		public void restartLevel ()
		{
				Application.LoadLevel (Application.loadedLevel);
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

				menuReset ();
				if (currentLevel != null) {
		
						currentLevel.gameObject.SetActive (false);
						
						currentLevel.endLevel ();
					
				}
				currentLevel = lev;
				AudioManager.thisAM.updateSliders ();
				currentLevel.gameObject.SetActive (true);
				RenderSettings.skybox = currentLevel.skybox;
				if (currentLevel.killPlayerOnEnter && myPlayer != null)
						die ();
				if (currentLevel.spawnable) {
						spawn ();
						
				}
				currentLevel.startLevel ();
				
				
		}

		


		//------------------------------------------------DEV CONSOLE----------------------------------------------------------\\


		public void dc_changeLevelThroughString ()
		{
				changeLvl (levelChangeString.text);
				transferLevelPlayer ();
		
		}
	
		public void dc_giveHealth ()
		{
				Tarsc player = myPlayer.GetComponent<Tarsc> ();
				player.thisAttributes.HP += int.Parse (giveHealthAmount.text);
				player.healthbar.value = player.thisAttributes.HP;

		
		}
	
		public void dc_giveGold ()
		{
				thisInv.addHoldable (currency,
		                     int.Parse (giveGoldAmount.text));
		}





		
}