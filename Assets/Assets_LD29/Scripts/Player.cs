using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		public float maxSped = 10f;
		bool turnR = true;
		Animator anim;
		bool grounded = false;
		public Transform groundCheck;
		float groundRad = 2f;
		public LayerMask whatGround;
		public float jump = 100;
		private health HP;
		public Rigidbody2D thisRigid;
		private string preLevel = " Version 1.1 Level : ";
		public int level = 0;
		public Vector3 pos;

		// Use this for initialization
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

		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{

				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatGround);
				anim.SetBool ("ground", grounded);
				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				float move = Input.GetAxis ("Horizontal");
				anim.SetFloat ("speed", Mathf.Abs (move));
				rigidbody2D.velocity = new Vector2 (move * maxSped, rigidbody2D.velocity.y);
				if (move > 0 && !turnR) {
						flip ();
				} else if (move < 0 && turnR) {
						flip ();
				}
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
						if (teleSpot.nextLevel) {
								level = teleSpot.level;
						}
				}
	
				if (other.gameObject.tag == "boost") {
						collisionBoost thisBoost = other.GetComponent<collisionBoost> ();
						thisRigid.AddForce (this.transform.position * (-1 * thisBoost.boostAmount));
				}
	
				if (other.gameObject.tag == "Enemy") {
		
				}
				if (other.gameObject.tag == "Destroyable") {
						Material temp = other.GetComponent<Material> ();
						temp.dropMadeOf (2);
				}
	
		}
}
