using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public float maxSped = 10f;
		public float moveForce = 5;
		public Transform groundCheck;
		public LayerMask whatGround;
		public float jump = 100;
		public int level = 0;
		public Vector3 pos;
		public GameObject landedParticles;
		public GameObject sideParticles;
		bool turnR = false;
		Animator anim;
		bool grounded = false;
		float groundRad = 0.16f;
		bool landed = false;
		Vector3 particlePos;
		private health HP;
		//private string preLevel = " Version 1.1 Level : ";


		void Start ()
		{
				anim = GetComponent <Animator> ();
				
		}
		
		void Update ()
		{
				if (grounded && Input.GetKeyDown (KeyCode.Space)) {
						anim.SetBool ("ground", false);
						rigidbody2D.AddForce (new Vector2 (0, jump));
				}

			
				if (rigidbody2D.velocity.y > 100) {
						Debug.Log ("boomFall");
						particlePos = new Vector3 (transform.position.x, transform.position.y - 5, -10);
						Instantiate (landedParticles, particlePos, Quaternion.identity);
				}
				if (rigidbody2D.velocity.y > 100) {
						Debug.Log ("boomRise");

						particlePos = new Vector3 (transform.position.x, transform.position.y + 5, -10);
						Instantiate (landedParticles, particlePos, Quaternion.identity);
				}
		}
		
	
		// Update is called once per frame
		void FixedUpdate ()
		{

				bool ground = Physics2D.Linecast (transform.position, groundCheck.position, whatGround); 
				if (!grounded && ground) {
						landed = true;
						grounded = true;


				} else if (!ground) {
						grounded = false;
						landed = false;


				} else {
						landed = false;


				}
					
					
		
				
				anim.SetBool ("ground", grounded);
				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

				float move = Input.GetAxis ("Horizontal");


				if (move < 0 && turnR) {
						flip ();
				} else if (move > 0 && !turnR) {
						flip ();
				}
				
				anim.SetFloat ("speed", Mathf.Abs (move));
				if (rigidbody2D.velocity.x < maxSped)
						rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x + (move * moveForce), rigidbody2D.velocity.y);
				
		}

		void flip ()
		{
				turnR = !turnR;
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = (Teleport)other.GetComponent ("Teleport");
						Vector3 teleTo = teleSpot.teleto.transform.position;
						this.transform.position = new Vector3 (teleTo.x - teleSpot.xOff,
			                                       teleTo.y - teleSpot.yOff, teleTo.z - teleSpot.zOff);
			
				}
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
						if (thisBoost == null)
								Debug.LogError ("no collision boost script attached");
						/*	float thisX = rigidbody2D.velocity.x / 2;
			float thisY = rigidbody2D.velocity.y / 2;
			
			Vector2 force = new Vector2 (thisX +((thisBoost.multiX) * thisBoost.boostAmount)
			                             , thisY + ((-thisBoost.multiY) * thisBoost.boostAmount));
			rigidbody2D.AddForceAtPosition (force, transform.position);

*/
						thisBoost.boost (rigidbody2D);
				}
		
		
				if (other.gameObject.tag == "Cannon") {
						cannon thisCannon = other.gameObject.GetComponent<cannon> ();
						if (thisCannon == null)
								Debug.LogError ("no cannon script attached");
						thisCannon.shoot ();
			
			
				}
		
		
		}



}
