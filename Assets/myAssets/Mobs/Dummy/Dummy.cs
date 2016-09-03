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
//						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "Player") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
//						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
				if (other.gameObject.tag == "NPC") {
						Vector2 force = new Vector2 (transform.position.x - other.transform.position.x, transform.position.y + 10 - other.transform.position.y);
						rigidbody2D.AddForce (force * Random.Range (100, 1000));
						takeDmg (thisAttributes.Dmg);
			
				}
		
		
		
		
		}
	
		protected override void TargetSight ()
		{
		
				if (target != null) {
						
						moveAi ();

//						checkLooking ();

			
						if (Vector2.Distance (target.transform.position, transform.position) > sight) {
								target = null;
								if (despawnWithDistance) {
										gameObject.SetActive (false);
								}
				
				
						}
				} else {
						selectTarget ();
						attacking = false;
						thisAttributes.moving = false;
				}
		
		}

		public override void moveAi ()
		{
				if (target.transform.position.y != transform.position.y)
						jump (thisAttributes.jump * Random.Range (1, 30));
		
		
				Vector2 targetPos = thisManage.transform.TransformPoint (target.transform.position);
				Vector2 thisPos = thisManage.transform.TransformPoint (transform.position);
		
				float move = 0;
		
				if (targetPos.x < thisPos.x) {
						move = (Vector2.right.x * -1);
			
				} else if (targetPos.x > thisPos.x) {
						move = (Vector2.right.x);
				}
		
				if (flipMob) {
						if (move < 0 && turnR) {
								flip ();
						} else if (move > 0 && !turnR) {
								flip ();
						}
			
				}
				moveX (move);
		

		}

		void OnTriggerEnter2D (Collider2D other)
		{

		
		}

		
	
}
