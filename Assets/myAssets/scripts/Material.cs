using UnityEngine;
using System.Collections;

public class Material : MonoBehaviour {
	public string name = "Tes";
	public GameObject madeOf;
	public Material madeOut;
	public bool destroyOnDrop = true;


	// Use this for initialization
	void Start () {
	if (madeOf != null) {
			madeOut = madeOf.GetComponent<Material>();
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 public void dropMadeOf(int howMuch){
		for(int i = 0;i < howMuch;i++){
			Vector3 pos = new Vector3(gameObject.transform.position.x+Random.Range(0,10)
			                          ,gameObject.transform.position.y);
		Instantiate (madeOf,pos,Quaternion.identity);
		}
		if (destroyOnDrop)
						Destroy (this.gameObject);

	}
}

