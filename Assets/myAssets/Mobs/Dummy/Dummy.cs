using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dummy : Enemy
{

		public string[] dialog;

		void Start ()
		{
		
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				InvokeRepeating ("updateDialog", 0, 5f);
				if (randomAttributes)
						resetAttributes ();
				checkNecesseries ();
		
		}
		public override  void die ()
		{
				if (dropMadeOF) {
						Resource r = GetComponent<Resource> ();
						r.dropMadeOf ();
				}
				Destroy (gameObject);

		}

		void updateDialog ()
		{
				GetComponent<textFade> ().responses.GetComponent<Text> ().text = dialog [Random.Range (0, dialog.Length)];

		}

		void OnCollisionEnter2D (Collision2D other)
		{

				if (other.gameObject.tag == "Destroyable") {
						Resource temp = other.gameObject.GetComponent<Resource> ();
						temp.dropMadeOf ();
				}
		
				if (other.gameObject.tag == "Enemy") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "NPC") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
		
		
		
		}


		
	
}
