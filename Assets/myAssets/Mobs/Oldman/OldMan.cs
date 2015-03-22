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
				talk.text = "Good choice, follow these arrows I have put down";
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
				for (int i = 0; i < 20; i++) {
						Invoke ("insBomb", Random.Range (0, 2f));
						

				}
		}
		void teleport ()
		{

				AudioSource.PlayClipAtPoint (movingClip, transform.position, 1);
				Destroy (this.gameObject, 5);
				particle.SetActive (true);
		}

		void insBomb ()
		{
				Vector2 pos = new Vector2 (transform.position.x + Random.Range (-50, 50), transform.position.y + Random.Range (0, 10));
				Instantiate (bomb, pos, Quaternion.identity);
		}

		void insHenchMan ()
		{
				GameObject g = (GameObject)Instantiate (henchMan, transform.position, Quaternion.identity);
				Mob1 hench = g.GetComponent<Mob1> ();
		}


}

