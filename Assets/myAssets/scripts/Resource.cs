using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
		//public string name = "Tes";
		public GameObject madeOf;
		public bool destroyOnDrop = true;
		public bool initailize;
		Rigidbody2D thisRigid;
		public int amountOfDrops;
		public bool randomAmountOfDrops;
		public GameObject[] res;
		public	bool dropManyTypesOfItems = false;

		// Use this for initialization
		void Start ()
		{
				thisRigid = GetComponent<Rigidbody2D> ();
				if (randomAmountOfDrops)
						amountOfDrops = Random.Range (1, amountOfDrops);
		}
	


		public void dropMadeOf ()
		{


				for (int i = 0; i < amountOfDrops; i++) {

						if (dropManyTypesOfItems)
								madeOf = res [Random.Range (0, res.Length)];
						Vector3 pos = new Vector3 (gameObject.transform.position.x + Random.Range (0, 10)
			                          , gameObject.transform.position.y);
						GameObject g = (GameObject)Instantiate (madeOf, pos, Quaternion.identity);
						if (initailize) {
								g.GetComponent<Entity> ().thisLevel = gameManager.thisM.currentLevel;
						}
						thisRigid.velocity.Set (-2, 5);
				}
				if (destroyOnDrop)
						Destroy (this.gameObject);

		}
}

