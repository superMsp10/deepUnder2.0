using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
		public string name = "Tes";
		public GameObject madeOf;
		public bool destroyOnDrop = true;
		Rigidbody2D thisRigid;


		// Use this for initialization
		void Start ()
		{
				thisRigid = GetComponent<Rigidbody2D> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void dropMadeOf (int howMuch)
		{
				for (int i = 0; i < howMuch; i++) {
						Vector3 pos = new Vector3 (gameObject.transform.position.x + Random.Range (0, 10)
			                          , gameObject.transform.position.y);
						Instantiate (madeOf, pos, Quaternion.identity);
						thisRigid.velocity.Set (-2, 5);
				}
				if (destroyOnDrop)
						Destroy (this.gameObject);

		}
}

