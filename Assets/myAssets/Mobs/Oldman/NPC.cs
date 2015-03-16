using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPC : Mob1
{
		public float talkDistance;
		public GameObject Target;
		public List<Quest> quests;
		public Quest currQuest;
		public LayerMask whatPlayer;
		public Text talk;
		public GameObject responses;
		public Button  answer1;
		public Button  answer2;
		
		public virtual void PlayerInteract ()
		{
				Debug.Log ("hi");
		}
		void Update ()
		{
				if (animated)
						updateAnim ();
				checkDead ();
				checkFacing ();
		}
		void OnTriggerEnter2D (Collider2D other)
		{
			
				if (other.gameObject.tag == "Player")
						responses.SetActive (true);
		}
		
		void OnTriggerExit2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						responses.SetActive (false);
		}

}

