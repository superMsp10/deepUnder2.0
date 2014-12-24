
using UnityEngine;
using System.Collections.Generic;

public class gameManager : MonoBehaviour
{


		public static gameManager thisM;
		public bool inGame = false;
		public level currentLevel;
		protected level start;
		public level[] levels;
		public bool dead = false;
		public bool loadDefault = false;

		//public string currMenu = "null";
		public Camera currCamera;
		
		
		// bool voted = false;
		// public
	
		private string version;
		//	private bool offline = false;
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
		// Use this for initialization
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
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						inGame = !inGame;
				}
		}

		//public void changeMenu (string menu)
		//{
		//		currMenu = menu;
		//	}

		void OnGUI ()
		{

				/*if (!inGame) {
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
					MySS = SS [Random.Range (0, SS.Length)];
					myPlayer = (GameObject)Instantiate
						(myPlayerIns, MySS.transform.position, MySS.transform.rotation);
					myPlayer.SetActive (true);
					currCamera = myPlayer.GetComponentInChildren<Camera> ();
					myHp = myPlayer.GetComponent<health> ();
					currMenu = "escape";
									
				}
							

			
			}
			if (currMenu == "escape") {
				if (GUILayout.Button ("respawn")) {
					myHp.Die ();
					currentLevel.camera1.SetActive (true);
					currMenu = "spawn";
				}
				if (GUILayout.Button ("jumpBoost")) {
					myPlayer.rigidbody2D.AddForce 
						(new Vector2 (0, 500), ForceMode2D.Impulse);
				}
			}
				}
		 */
				
			
					
					
					
								

								
						
			
					
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

		private void levelex (level lev)
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
						
				}
				currentLevel.startLevel ();
				foreach (level l in levels) {
						l.votes = 0;
				}
				
		}
		
		void OnDestroy ()
		{
				


		}
}