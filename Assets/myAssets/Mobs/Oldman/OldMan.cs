using UnityEngine;
using System.Collections;

public class OldMan : NPC
{
		public bool follow;
		public bool attacked = false;

		public GameObject arrow;
		public GameObject bombPick;
		public GameObject particle;
		public GameObject bomb;
		public GameObject henchMan;
		public GameObject henchMan2;
		public GameObject insPos;

		public GameObject[] enemies;

		public level tele;
		public Transform where;
		public bool stage2 = false;
		bool hostile = true;


		protected override void speechStart ()
		{
				updateSpeech (false);
		}


		protected override  void updateSpeech (bool answer)
		{
				if (speakStage == "awake") {
						talk.text = "I have been waiting for you" + "\n" + "Follow Me";
						answer1Text.text = "Yes";
						answer2Text.text = "No";
						speakStage = "started";
						goto end;
			
				}

				if (speakStage == "started") {
						if (answer) {
								follow_talk ();
								goto end;
						} else {
								speakStage = "forgive";
								kill ();
								talk.text = "FINE HAVE IT YOUR WAY!";
								answer1Text.text = "Good";
								answer2Text.text = "I don't care";
								talking = false;
								goto end;

						}

				}
				if (speakStage == "follow") {
						if (answer) {
								speakStage = "plan";

								flyAway ();
								Invoke ("labHappy", 7f);

								goto end;

						} else {
								speakStage = "mock";
								
								mock ();
								goto end;
							
						}
				}

				if (speakStage == "mock") {
						
						if (answer) {
								follow_talk ();
								goto end;
						} else {
								speakStage = "forgive";
								talk.text = "FINE HAVE IT YOUR WAY!";
								answer1Text.text = "Good";
								answer2Text.text = "I dont care";
								kill ();
								goto end;
						}

				}

				
				if (speakStage == "plan") {
						if (answer) {

								changeTalkBoxState (true);
								talk.text = "Alright, you must kill the groth. The signs will lead you to it, GO NOW!";
								answer1Text.text = "Ok";
								answer2Text.text = "No never!";
								speakStage = "plan";
								hostile = false;
								goto end;
						} else {
								speakStage = "kill2";
								mock2 ();
								goto end;
						}
				}
			


				if (speakStage == "forgive") {
			
						if (answer) {
								changeTalkBoxState (true);
								talk.text = "OK, boy i will let you go if you work with me";
								answer1Text.text = "Ok";
								answer2Text.text = "Not happenening";
								speakStage = "plan";
								goto end;
						} else {
								changeTalkBoxState (true);
								talk.text = "Final words";
								answer1Text.text = "NO";
								answer2Text.text = "whats the worst that can happen";
								speakStage = "kill2";
								attack ();
								goto end;
						}
				}
				end:
				;
		}

		void mock ()
		{
				changeTalkBoxState (true);
				talk.text = "BOY! stop mocking me";
				answer1Text.text = "Im sorry";
				answer2Text.text = "No";

		}

		void attack ()
		{
				thisManage.deathEnd = true;
				if (!attacked) {
						foreach (GameObject g in enemies) {
								g.SetActive (true);
						}
						attacked = true;
				}
		}

		void mock2 ()
		{
				talking = false;
				talk.text = "How dare you revolt against me!";
				answer1Text.text = "Im sorry...";
				answer2Text.text = "I will never follow you!";
				attack ();
		}

		void follow_talk ()
		{
				answer1Text.text = "Yes";
				answer2Text.text = "No";
				talk.text = "Good choice, follow these signs I have put down";
				speakStage = "follow";
				changeTalkBoxState (true);

		}

		void labHappy ()
		{
				talking = true;

				talk.text = "Boy welcome to my lab! Gear up, and speak to me when you are ready";
				answer1Text.text = "Ready!";
				answer2Text.text = "Never!";
				speakStage = "plan";

		}

		void flyAway ()
		{
				talking = false;
				rigidbody2D.gravityScale = -0.2f;
				Invoke ("teleport", 5);
				arrow.SetActive (true);
				transform.FindChild ("particles").gameObject.SetActive (true);
				bombPick.SetActive (true);
				AudioSource.PlayClipAtPoint (jumpClip, transform.position, AudioManager.thisAM.playerFX.volume);
		}

		void kill ()
		{

				flyAway ();
				for (int i = 0; i < 100; i++) {
						Invoke ("insBomb", Random.Range (0.5f, 10f));
						Invoke ("insBomb", Random.Range (1, 5));
				}
				Invoke ("insHenchMan", 5);
				Invoke ("labMad", 9f);

		}
		void teleport ()
		{

				AudioSource.PlayClipAtPoint (movingClip, transform.position, AudioManager.thisAM.playerFX.volume);
				particle.SetActive (true);
				Invoke ("changeLev", 2f);


		}

		void labMad ()
		{
				talking = true;
				talk.text = "Boy welcome to my lab, Muhahahaw";
				answer1Text.text = "Oh no, Noo!";
				answer2Text.text = "Bring it!";
		}

		void changeLev ()
		{
				changeLevel (tele);

				transform.position = where.position;
				particle.SetActive (false);
				transform.FindChild ("particles").gameObject.SetActive (false);
				
				rigidbody2D.gravityScale = 2f;

				stage2 = true;


		}

		void insBomb ()
		{
				Vector2 pos;
				if (stage2) {
						pos = transform.position;
						pos = new Vector2 (pos.x + Random.Range (-60, 100), pos.y + Random.Range (20, 80));
				} else {
						pos = new Vector2 (insPos.transform.position.x + Random.Range (-60, 100), insPos.transform.position.y + Random.Range (20, 80));
				}
				GameObject g = (GameObject)Instantiate (bomb, pos, Quaternion.identity);
				g.rigidbody2D.AddForce (new Vector2 (Random.Range (-8000, 8000), Random.Range (0, 8000)));
				g.rigidbody2D.AddTorque (Random.Range (-80, 80));
				
		}

		void insHenchMan ()
		{
				henchMan.SetActive (true);
				henchMan2.SetActive (true);

		}

		public override void takeDmg (float damage)
		{
				thisAttributes.HP -= damage;
				if (thisAudio == null) {
			
						thisAudio = AudioManager.thisAM.playerFX;
				}
				thisAudio.PlayOneShot (dmgClip);
				healthbar.value = thisAttributes.HP;

				if (stage2 && hostile) {
						changeTalkBoxState (true);
						talk.text = "How dare you attack ME!Now meet your end!";
						answer1Text.text = "Im sorry";
						answer2Text.text = "No i didnt mean to..";
						talking = false;
						attack ();
				}
		}


		void OnCollisionEnter2D (Collision2D other)
		{
		
		
				if (other.gameObject.tag == "Destroyable") {
						Resource temp = other.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf ();
				}
		
				if (other.gameObject.tag == "Enemy") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "NPC") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}

		}

		void OnTriggerEnter2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						changeTalkBoxState (true);
	
		
		}
}

