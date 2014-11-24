using UnityEngine;
using System.Collections;

public class DupliCator : Entity
{
		public GameObject dup;
		public bool auto;
		public float autoTime;
		public Transform location;
		public int randomOff = 0;
		public int dupAmount;
		public int ranRot = 0;
		// Use this for initialization
		void Start ()
		{
				if (auto)
						InvokeRepeating ("duplicate", 0, autoTime);
				else
						duplicate ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void duplicate ()
		{
				for (int i = 0; i < dupAmount; i++) {
						Invoke ("dupli", 0);
				}


		}

		void dupli ()
		{
				Vector3 dupPos = new Vector3 (location.position.x + Random.Range (0, randomOff)
		                              , location.position.y + Random.Range (0, randomOff));
				
				Quaternion dupRot = new Quaternion (location.rotation.x + Random.Range (0, ranRot)
		                               , location.rotation.y + Random.Range (0, ranRot), 0, 0);
				GameObject g = (GameObject)GameObject.Instantiate (dup, dupPos, dupRot);
				Entity e = g.GetComponent<Entity> ();
				e.thisManage = thisManage;
				e.thisLevel = thisLevel;

		
		
		}
}

