using UnityEngine;
using System.Collections.Generic;

public class NetworkManeger : MonoBehaviour
{

		public List<GameObject> players;
		public int dethHeight;
		public bool inGame;
		public level currentLevel;
		public level start;
		public level[] levels;
		public bool dead = false;
		public bool firstPlayer = false;
		public string currMenu = "null";
		public bool voted = false;
		// public

		private string version;
		private bool offline = false;
		private GameObject myPlayer;
		private SpawnSpot[] SS;
		private SpawnSpot MySS;
		private bool connecting = false;
		List <string> chatMessages;
		int MaxChatMess = 5;
		private string code = "";
		private string status = "[newbie]";
		private string gameMode = "  ";
		private bool spec = false;
		GameObject specPlayer;
		private PhotonView thisView;
		int randomVote = 0;
		private health myHp;

		//UnityStuff
		void Start ()
		{
				version = "NetTest 0.2.2";
				PhotonNetwork.player.name = PlayerPrefs.GetString ("UserName", "EnterNameHere");
				thisView = this.GetComponent<PhotonView> ();
				chatMessages = new List<string> ();
				levels = FindObjectsOfType<level> ();
				foreach (level l in levels) {
						l.gameObject.SetActive (false);
				}
				changeLvl ("startMenu");
				MaxChatMess = 5;
		inGame = false;
				

		}

		void Update ()
		{
	
				if (myPlayer != null && myPlayer.transform.position.y < dethHeight) {
						
						MySS = SS [Random.Range (0, SS.Length)];
						myPlayer.transform.position = MySS.transform.position;
				}
				/*if (inGame) {

						Screen.lockCursor = true;
						Screen.showCursor = false;
						Time.timeScale = 1;
						currMenu = "null";
			Debug.Log("Ingame");

						
				} else {
						if (currMenu == "null") {
								currMenu = "escape";
						}

						Screen.lockCursor = false;
						Screen.showCursor = true;



				}*/
				
				

		}

		void OnGUI ()
		{
				if (inGame) {
						if (offline) {
								GUILayout.Label (version + "  " + "OfflineMode" + "   " + gameMode);
						} else {
			
								GUILayout.Label (version + "  " + PhotonNetwork.connectionStateDetailed.ToString () + "   " + gameMode);
						}
				}

				if ((!inGame) && PhotonNetwork.connected && (!connecting) && !dead) {
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
								if (status == "[Dev]") {

									
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

				}

				if (dead) {
						inGame = false;
						GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
						GUILayout.BeginVertical ();
						GUILayout.FlexibleSpace ();

						GUILayout.BeginHorizontal ();

						if (GUILayout.Button ("Spawn") && PhotonNetwork.connected) {
								dead = false;
								if (spec && specPlayer != null)
										specPlayer.transform.FindChild ("soldier").FindChild ("Hips")
						.FindChild ("Camera").gameObject.SetActive (false);

								CreatePlayer ();
					
								
						}
						
						

						if (currMenu == "Spectate") {
								foreach (GameObject player in players) {
										if (GUILayout.Button (player.name)) {
											
												if (spec && specPlayer != null)
														specPlayer.transform.FindChild ("soldier").FindChild ("Hips")
							.FindChild ("Camera").gameObject.SetActive (false);
												player.transform.FindChild ("soldier").FindChild ("Hips").
							FindChild ("Camera").gameObject.SetActive (true);
												specPlayer = player;
												spec = true;
										}
								}
								if (GUILayout.Button ("Standby")) {
										if (spec && specPlayer != null)
												specPlayer.transform.FindChild ("soldier").FindChild ("Hips")
							.FindChild ("Camera").gameObject.SetActive (false);
										spec = false;
										
										specPlayer = null;

								}

						} else if (players.Count != 0) {
								if (GUILayout.Button ("Spectate")) {
										currMenu = "Spectate";
								}

						}
					
						
						GUILayout.FlexibleSpace ();
						GUILayout.EndVertical ();
						GUILayout.EndArea ();


				}
				

		
				if (PhotonNetwork.connected == false && connecting == false) {
						inGame = false;

						GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
						GUILayout.BeginHorizontal ();
						GUILayout.FlexibleSpace ();
						GUILayout.BeginVertical ();
						GUILayout.Space (20);
						
						GUILayout.BeginHorizontal ();
						GUILayout.Label ("UserName: ");
						PhotonNetwork.player.name = GUILayout.TextField (PhotonNetwork.player.name);
			
						GUILayout.EndHorizontal ();
			
						GUILayout.BeginHorizontal ();
						GUILayout.Label ("Code: ");
						code = GUILayout.PasswordField (code, "*" [0], 20);
			
			
						GUILayout.EndHorizontal ();
			
			
						if (GUILayout.Button ("Play!")) {
								connecting = true;
								status = "[admin]";
								PhotonNetwork.offlineMode = true;
								OnJoinedLobby ();
								offline = true;
								gameMode = "freedom";
								changeLvl ("1");
								inGame = true;

						}
			
			
					
						GUILayout.FlexibleSpace ();
						GUILayout.EndVertical ();
						GUILayout.FlexibleSpace ();
						GUILayout.EndHorizontal ();
						GUILayout.EndArea ();
				}
				if (PhotonNetwork.connected && connecting == false) {
						GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
						GUILayout.BeginVertical ();
						GUILayout.FlexibleSpace ();
						foreach (string mess in chatMessages) {
								GUILayout.Label (mess);
						}
			
						GUILayout.EndVertical ();
						GUILayout.EndArea ();
			
				}
				
		}

		void OnDestroy ()
		{
				PlayerPrefs.SetString ("UserName", PhotonNetwork.player.name);
		}

		//PhotonStuff

		void Connect ()
		{
				PhotonNetwork.ConnectUsingSettings (version);
		}

		void OnJoinedLobby ()
		{
				PhotonNetwork.JoinRandomRoom ();
		}

		void OnJoinedRoom ()
		{
				connecting = false;
				if (firstPlayer) {
					
						thisView.RPC ("changeLvl", PhotonTargets.OthersBuffered, "1" +
								"");
				}
		}

		void OnPhotonRandomJoinFailed ()
		{
				firstPlayer = true;
				PhotonNetwork.CreateRoom ("randomCreated");
				
				
		}

		//MyStuff

	
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
	
		
		[RPC]
		void addChatMassage_RPC (string message)
		{
				if (chatMessages.Count >= MaxChatMess) {
						chatMessages.RemoveAt (0);
				}
				chatMessages.Add (message);
		}

		[RPC]
		void playerJoin (string name, int playerId)
		{

				GameObject[] t = GameObject.FindGameObjectsWithTag ("Player");

				foreach (GameObject i  in t) {
						if (i.GetComponent<PhotonView> ().ownerId == playerId) {
								i.gameObject.name = name;
								players.Add (i);
						} 
				}
		}

		[RPC]
		public void vote (string lev)
		{
				foreach (level l in levels) {
						if (l.name == lev) {
								l.votes++;
						}
				}
		
		}

		private void levelex (level lev)
		{
				voted = false;
				if (currentLevel != null) {
					
						currentLevel.gameObject.SetActive (false);
						if (myPlayer != null) {
								myHp.Die ();
						}
								
				}
				currentLevel = lev;
				currentLevel.gameObject.SetActive (true);
				currentLevel.camera1.SetActive (true);
				
				if (currentLevel.spawnable) {
						dead = true;
						SS = FindObjectsOfType<SpawnSpot> ();
						if (PhotonNetwork.connected) {
								foreach (level l in levels) {
										l.votes = 0;

								}

						}

				} else if (PhotonNetwork.connected)
						changeLvl ("cottage");	
		}
	
		public void addChatMassage (string message)
		{
				thisView.RPC ("addChatMassage_RPC", PhotonTargets.All, status + " " + message);
		}

		void CreatePlayer ()
		{

				MySS = SS [Random.Range (0, SS.Length)];
				if (!offline) {
						myPlayer.name = PhotonNetwork.player.name;
				}
				myPlayer = (GameObject)PhotonNetwork.Instantiate ("player", MySS.transform.position, MySS.transform.rotation, 0);
				myHp = myPlayer.GetComponent <health> ();
		myHp.enabled = true;
		myPlayer.GetComponent<character> ().enabled = true;
		myPlayer.transform.FindChild ("Camera").gameObject.SetActive(true);
	
				 
				
				players.Add (myPlayer);
				currentLevel.camera1.SetActive (false);
		}

}
