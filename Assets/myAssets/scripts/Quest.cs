using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour
{

		public bool started;
		public bool finished;
		public questManager thisQuest;
		public void startQuest ()
		{
				started = true;
				Debug.Log ("started");
				thisQuest = questManager.thisQuest;

		}

		public void updateQuest ()
		{
				if (started)
						Debug.Log ("hi");
				if (finished)
						Debug.Log ("ended");
		}

		public void endQuest ()
		{
				finished = true;
				Debug.Log ("finished");
		}
		
}

