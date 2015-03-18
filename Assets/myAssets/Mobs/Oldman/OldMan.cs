using UnityEngine;
using System.Collections;

public class OldMan : NPC
{
		public bool follow;
		public GameObject arrow;
		public GameObject particle;

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
								talk.text = "Good choice, follow these arrows I have put down";
								speakStage = "follow";
								talking = true;
								changeTalkBoxState (true);
								goto end;
						}

				}
				if (speakStage == "follow") {
						if (answer) {
								rigidbody2D.gravityScale = -0.2f;
								Invoke ("teleport", 5);
								arrow.SetActive (true);
								transform.FindChild ("particles").gameObject.SetActive (true);

						}
				}
				end:
				;
		}

		void teleport ()
		{

				Destroy (this.gameObject, 5);
				particle.SetActive (true);
		}


}

