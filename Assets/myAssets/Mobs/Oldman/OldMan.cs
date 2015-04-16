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


		public level tele;
		public Transform where;


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
								flyAway ();
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

				if (speakStage == "kill2") {
			
						changeTalkBoxState (true);
						talk.text = "Final words";
						answer1Text.text = "NO";
						answer2Text.text = "whats the worst that can happen";
						speakStage = "kill2";
						goto end;
				}
			
				
				if (speakStage == "plan") {
						if (answer) {

								changeTalkBoxState (true);
								talk.text = "Go gear up and follow the signs, when you see a monster";
								answer1Text.text = "Ok";
								answer2Text.text = "Are you a monster";
								speakStage = "plan";
								goto end;
						} else {
								speakStage = "kill";
								kill ();
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
								talk.text = "It will all be over before you know it";
								answer1Text.text = "Baloney";
								answer2Text.text = "You cant touch this!";
								speakStage = "kill2";
								goto end;
						}
				}
			


				if (speakStage == "kill") {
						if (answer) {
								changeTalkBoxState (true);
								talk.text = "Thats right boy, Henchmen!!";
								answer1Text.text = "Im sorry, :0";
								answer2Text.text = "1v1 me";
								speakStage = "forgive";

								goto end;
						} else {
								changeTalkBoxState (true);
								talk.text = "It will all be over before you know it";
								answer1Text.text = "Baloney";
								answer2Text.text = "You cant touch this!";
								speakStage = "kill2";
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

		void mock2 ()
		{

		}

		void follow_talk ()
		{
				answer1Text.text = "Yes";
				answer2Text.text = "No";
				talk.text = "Good choice, follow these signs I have put down";
				speakStage = "follow";
				changeTalkBoxState (true);

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
				for (int i = 0; i < 50; i++) {
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




		}

		void insBomb ()
		{
				Vector2 pos;
				
				pos = new Vector2 (insPos.transform.position.x + Random.Range (-60, 100), insPos.transform.position.y + Random.Range (20, 80));
				Instantiate (bomb, pos, Quaternion.identity);
				
		}

		void insHenchMan ()
		{
				henchMan.SetActive (true);
				henchMan2.SetActive (true);

		}


}

