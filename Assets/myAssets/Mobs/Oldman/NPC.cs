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

				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = other.GetComponent<Teleport> ();
						teleSpot.teleport (gameObject);
			
				}
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
						if (thisBoost == null)
								Debug.LogError ("no collision boost script attached");
						thisBoost.boost (rigidbody2D);
				}

				if (other.gameObject.tag == "NPC") {
						NPC thisCannon = other.gameObject.GetComponent<NPC> ();
						if (thisCannon == null)
								Debug.LogError ("no NPC script attached but tag is NPC");
						thisCannon.PlayerInteract ();
			
				}

		}
		
		void OnTriggerExit2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						responses.SetActive (false);
		}

		public void button1Click ()
		{
				Debug.Log ("hi");


		}

		public void button2Click ()
		{

				Debug.Log ("hi");


		}
}

