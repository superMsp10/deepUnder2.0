using UnityEngine;
using System.Collections.Generic;

public class BodyParts : MonoBehaviour
{
		DistanceJoint2D thisJoint;
		public GameObject[] destroy;
		//----------------------------
		public int maxVelo = 10;
		public Mob1 thisMob;
		private Entity thisEn;
		public BodyParts conBody;
		public bool connected;
		// Use this for initialization
		void Start ()
		{
				thisEn = GetComponent<Entity> ();
				thisJoint = GetComponent<DistanceJoint2D> ();
				if (!connected) {
						thisJoint.enabled = false;
						rigidbody2D.isKinematic = true;
				
				} else {
						rigidbody2D.isKinematic = false;

				}
		}

		public void Join (BodyParts connect, Mob1 mobConnect)
		{
				connected = true;
				thisMob = mobConnect;



		}

		public void Join (BodyParts connect)
		{
		
		
		
		}
}
