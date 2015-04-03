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
		public level tele;
		public Transform where;


		protected override void speechStart ()
		{
				talk.text = "I have been waiting for you" + "\n" + "Follow Me";
				answer1Text.text = "Yes";
				answer2Text.text = "No";
				speakStage = "started";
		}
		protected override  void updateSpeech (bool answer)
		{

				if (speakStage == "started") {
						if (answer) {
								follow_talk ();
								goto end;
						} else {
								speakStage = "kill";
								kill ();
								
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
								kill ();
								goto end;
						}

				}

				if (speakStage == "kill") {

						
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
				rigidbody2D.gravityScale = -0.2f;
				Invoke ("teleport", 5);
				arrow.SetActive (true);
				transform.FindChild ("particles").gameObject.SetActive (true);
				bombPick.SetActive (true);
				AudioSource.PlayClipAtPoint (jumpClip, transform.position, 1);
		}

		void kill ()
		{
				changeTalkBoxState (true);
				talk.text = "FINE HAVE IT YOUR WAY!";
				answer1Text.text = "Good";
				answer2Text.text = "I dont care";
				flyAway ();
				for (int i = 0; i < 80; i++) {
						Invoke ("insBomb", Random.Range (0.5f, 10f));
				}
				Invoke ("insHenchMan", 5);
		}
		void teleport ()
		{

				AudioSource.PlayClipAtPoint (movingClip, transform.position, 1);
				gameObject.SetActive (false);
				changeLevel (tele);
				particle.SetActive (true);
				transform.position = where.position;
		}

		void insBomb ()
		{
				Vector2 pos;
				
				pos = new Vector2 (transform.position.x + Random.Range (-60, 100), transform.position.y + Random.Range (20, 80));
				Instantiate (bomb, pos, Quaternion.identity);
				
		}

		void insHenchMan ()
		{
				henchMan.SetActive (true);
		}


}

