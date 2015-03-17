using UnityEngine;
using System.Collections;

public class OldMan : NPC
{
		public bool follow;
		public GameObject arrow;
		
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
						}

				}
				if (speakStage == "follow") {

				}
		
		}

}

