using UnityEngine;
using System.Collections;

public class OldMan : NPC
{
		
		
		protected override void speechStart ()
		{
				talk.text = "I have been waiting for you" + "\n" + "Follow Me";
				answer1Text.text = "Yes";
				answer2Text.text = "No";

		}
}

