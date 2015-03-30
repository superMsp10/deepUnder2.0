using UnityEngine;
using System.Collections;

public class textFade : MonoBehaviour
{
		public GameObject responses;
		void OnTriggerEnter2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						changeTalkBoxState (true);
		}

		void OnTriggerExit2D (Collider2D other)
		{
		
				if (other.gameObject.tag == "Player")
						changeTalkBoxState (false);
		}

		public void changeTalkBoxState (bool response)
		{
		
				if (response) {
			
						responses.SetActive (response);

				} else {
						responses.SetActive (false);
				}
		}
		
			
}

