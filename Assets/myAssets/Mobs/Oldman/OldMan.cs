using UnityEngine;
using System.Collections;

public class OldMan : NPC
{
		public bool follow;
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
								speakStage = "kill";
								kill ();
								talk.text = "FINE HAVE IT YOUR WAY!";
								answer1Text.text = "Good";
								answer2Text.text = "I dont care";
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
								speakStage = "kill";
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
								talk.text = "Gear up, Follow the signs, and when you see a monster attack it!";
								answer1Text.text = "Ok";
								answer2Text.text = "Are you a monster";
								speakStage = "plan";
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
			



				if (speakStage == "kill") {
						
						changeTalkBoxState (true);
						talk.text = "Thats right boy, HENCHMEN!!";
						answer1Text.text = "Im sorry, :0";
						answer2Text.text = "1v1 me";
						speakStage = "forgive";

						goto end;
						
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
				foreach (GameObject g in enemies) {
						g.SetActive (true);
				}
			
		}

		void mock2 ()
		{
				talking = false;
				talk.text = "How dare you insult ME!";
				answer1Text.text = "I didnt mean it that way";
				answer2Text.text = " Are you a monster";
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

				talk.text = "Gear up, Follow the signs, and when you see a monster attack it!";
				answer1Text.text = "Ok";
				answer2Text.text = "Are you a monster";
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

}

