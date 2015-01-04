using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour
{

		public bool started;
		public bool finished;
		public void startQuest ()
		{
				started = true;
				Debug.Log ("started");

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

