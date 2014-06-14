using UnityEngine;
using System.Collections;

public class playerconteoller : MonoBehaviour
{
		public float speed;
		public GUIText countText;
		private int count;
		public GUIText winText;
		void Start ()
		{
				count = 0;
				setGuiText ();
				winText.text = "";
		}

		void FixedUpdate ()
		{
				float movehorizontal = Input.GetAxis ("Horizontal");
				float movevertical = Input.GetAxis ("Vertical");

				Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
				rigidbody.AddForce (movement * speed * Time.deltaTime);
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == "pickup") {
						other.gameObject.SetActive (false);
						count++;
						setGuiText ();
				
						if (count >= 6)
								winText.text = "YOU WON!!";
				}
		}

		void setGuiText ()
		{
				countText.text = "collected: " + count.ToString();
		}
}
