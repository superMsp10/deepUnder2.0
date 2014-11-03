
using UnityEngine;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{


		public bool inGame = false;
		public level currentLevel;
		public level start;
		public level[] levels;
		public bool dead = false;
		public string currMenu = "null";
		public bool voted = false;
		public Camera currCamera;
		// public
	
		private string version;
	//	private bool offline = false;
		public GameObject myPlayer;
		private SpawnSpot[] SS;
		private SpawnSpot MySS;
		private bool connecting = false;
		List <string> chatMessages;
		int MaxChatMess = 5;
		private string code = "";
		private string status = "[newbie]";
		private health myHp;

		// Use this for initialization
		void Start ()
		{		
				version = "NetTest 0.2.2";
				PhotonNetwork.player.name = PlayerPrefs.GetString ("UserName", "EnterNameHere");
				levels = FindObjectsOfType<level> ();
				foreach (level l in levels) {
						l.gameObject.SetActive (false);
				}

				changeLvl ("startMenu");

				inGame = false;
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		void OnGUI ()
		{

				if (!inGame) {
						if (currMenu == "null") {
								GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
								GUILayout.BeginHorizontal ();
								GUILayout.FlexibleSpace ();
								GUILayout.BeginVertical ();
								GUILayout.Space (20);
				
								GUILayout.BeginHorizontal ();
								GUILayout.Label ("PlayerName: ");
								PhotonNetwork.player.name = GUILayout.TextField (PhotonNetwork.player.name);
				
								GUILayout.EndHorizontal ();
				
								GUILayout.BeginHorizontal ();
								GUILayout.Label ("LevelCode: ");
								code = GUILayout.PasswordField (code, "*" [0], 20);
				
				
								GUILayout.EndHorizontal ();
				
				
								if (GUILayout.Button ("Play!")) {
										changeLvl (1);
										myHp = myPlayer.GetComponent<health> ();
										currMenu = "spawn";
									
					
								}
								GUILayout.FlexibleSpace ();
								GUILayout.EndVertical ();
								GUILayout.FlexibleSpace ();
								GUILayout.EndHorizontal ();
								GUILayout.EndArea ();
								
				
				
				
								
						}
						if (currMenu == "spawn") {
						
								if (GUILayout.Button ("Appcept Level")) {
										currentLevel.camera1.SetActive (false);
										inGame = true;

										myPlayer.SetActive (true);
										currCamera = myPlayer.GetComponentInChildren<Camera>();
									
								}
							

						}
				}
				/*
						if (currMenu == "escape") {
								if (GUILayout.Button (status + " Status Powers")) {
										currMenu = "statusPower";
								}
						}
						if (currMenu == "statusPower") {
								if (status == "[newbie]") {
					
					
					
								}
								if (status == "[admin]") {
					
										if (GUILayout.Button ("Random level")) {
												int rLevel = Random.Range (0, levels.Length);
												changeLvl (rLevel);
						
										}
										foreach (level l in levels) {
												if (l.spawnable) {
														if (GUILayout.Button (l.name)) {
																voted = true;
																changeLvl (l.name);
																//addChatMassage(myPlayer.name + " has voted to change the level into " + l.name);
																//thisView.RPC ("vote", PhotonTargets.All, l.name);
								
														}
							
												}
										}
					
					
								}

								
						}
			
				
					*/
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

		private void levelex (level lev)
		{
				voted = false;
				if (currentLevel != null) {
			
						myPlayer.SetActive (false);
						dead = true;
						currentLevel.gameObject.SetActive (false);
				}
				currentLevel = lev;
				currentLevel.gameObject.SetActive (true);
				currentLevel.camera1.SetActive (true);
				currCamera = currentLevel.camera1.camera;
				
		
				if (currentLevel.spawnable) {
						dead = true;
						SS = FindObjectsOfType<SpawnSpot> ();
						

						if (PhotonNetwork.connected) {

						}
						foreach (level l in levels) {
								l.votes = 0;
						}
				
				}
			
		} 
		
}