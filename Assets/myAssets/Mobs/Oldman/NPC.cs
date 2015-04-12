using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class NPC : Mob1
{
		public float talkDistance;
		public GameObject Target;
		public LayerMask whatPlayer;
		public Text talk;
		public GameObject responses;
		public Button  answer1;
		protected	Text  answer1Text;
		public Button  answer2;
		protected	Text  answer2Text;
		public bool talking = true;
		public string speakStage = "start";
		
		void Start ()
		{
				thisManage = gameManager.thisM;
				checkNecesseries ();
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				answer1Text = answer1.GetComponentInChildren<Text> ();
				answer2Text = answer2.GetComponentInChildren<Text> ();
				speechStart ();

		}

		protected virtual void speechStart ()
		{


		}

		protected virtual  void updateSpeech (bool answer)
		{

		}
		void Update ()
		{
				if (animated)
						updateAnim ();
				checkDead ();
				checkFacing ();
		}

		public void changeTalkBoxState (bool response)
		{

				if (response) {

						responses.SetActive (response);
						talking = true;

				} else {
						responses.SetActive (false);
						talking = false;
				}
		}
		void OnTriggerEnter2D (Collider2D other)
		{
			
				if (other.gameObject.tag == "Player")
						changeTalkBoxState (true);
				if (thisAttributes.teleports) {
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
				}
				if (other.gameObject.tag == "NPC") {
						NPC thisCannon = other.gameObject.GetComponent<NPC> ();
						if (thisCannon == null)
								Debug.LogError ("no NPC script attached but tag is NPC :" + gameObject.name);
					
			
				}

		}
		
		void OnTriggerExit2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						changeTalkBoxState (false);
		}

		public void button1Click ()
		{

			
				changeTalkBoxState (false);
				updateSpeech (true);
		}

		public void button2Click ()
		{

	
				changeTalkBoxState (false);
				updateSpeech (false);


		}
}

