using UnityEngine;
using System.Collections;

public class Ranach : NPC
{

		public GameObject drop ;
	
		protected override void speechStart ()
		{
				talk.text = "BOY! you are in great danger";
				answer1Text.text = "Why?";
				answer2Text.text = "No";
				speakStage = "started";
		}

		protected override  void updateSpeech (bool answer)
		{
		
				if (speakStage == "started") {
						if (answer) {
								talk.text = "The old man wants to use you as his weapon";
								answer1Text.text = "What can i do?";
								answer2Text.text = "baloney!";
								speakStage = "plan";
						} else {
								talk.text = "BOY! trust me that old man is evil";
								answer1Text.text = "What can i do?";
								answer2Text.text = "So?";
								speakStage = "plan";

						}
				}

				if (speakStage == "plan") {
			if(answer)

				}
		}



		void giveWeapon ()
		{
				talk.text = "Take this and attack the old man when you see him";
				drop.SetActive (true);
		}
}