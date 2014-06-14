using UnityEngine;
using System.Collections;

public class character : MonoBehaviour
{
		bool jump = false;
		public int maxSpeed = 100;
		public int moveForce = 100;
		public int jumpForce = 100;
		public GUIText Level;
		private health HP;
		public Rigidbody2D thisRigid;
		private string preLevel = " Version 1.1 Level : ";
		public int level = 0;
		public Vector3 pos;
		private bool grounded = false;
		Transform feets;
		// Use this for initialization
		void Start ()
		{
				feets = this.gameObject.transform.FindChild ("feets");
				if (feets == null) {

						Debug.LogError ("nooo feets");
				}
				Level.color = Color.magenta;
				Level.text = preLevel + level.ToString ();
				HP = this.GetComponent <health> ();
				thisRigid = GetComponent<Rigidbody2D> ();
				pos = transform.position;

		}

		void Update ()
		{
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
				grounded = Physics2D.Linecast (transform.position, feets.position, 1 << LayerMask.NameToLayer ("Ground"));  
		
				// If the jump button is pressed and the player is grounded then the player should jump.
				if (Input.GetButtonDown ("Jump") && grounded) {
						jump = true;
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
	
				if (other.gameObject.tag == "teleport") {
						Teleport teleSpot = (Teleport)other.GetComponent ("Teleport");
						Vector3 teleTo = teleSpot.teleto.transform.position;
						this.transform.position = new Vector3 (teleTo.x - teleSpot.xOff,
			                                      teleTo.y - teleSpot.yOff, teleTo.z - teleSpot.zOff);
						if (teleSpot.nextLevel) {
								level = teleSpot.level;
								if (level == 100)
										Level.text = "YOU WON!!!!!";
								else
										Level.text = preLevel + level.ToString ();

						}
				}

				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.GetComponent<collisionBoost> ();
						thisRigid.AddForce (this.transform.position * (-1 * thisBoost.boostAmount));
				}

				if (other.gameObject.tag == "Enemy") {

				}
		}
	
		void FixedUpdate ()
		{ 
				// Cache the horizontal input.
				float h = Input.GetAxis ("Horizontal");
		
				//
				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
				// If the input is moving the player right and the player is facing left...

				// If the player should jump...
				if (jump) {
						// Set the Jump animator trigger parameter.
		
						// Add a vertical force to the player.

						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
			
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}
		}
}
