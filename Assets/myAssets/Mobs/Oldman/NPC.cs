using UnityEngine;
using System.Collections.Generic;

public class NPC : Mob1
{
		public float talkDistance;
		public GameObject Target;
		public List<Quest> quests;
		public Quest currQuest;
		
		public virtual void PlayerInteract ()
		{
				Debug.Log ("hi");
		}

}

