using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class DestroyDetails
{
		
		public bool destroyOnAwake;			// Whether or not this gameobject should destroyed after a delay, on Awake.
		public float awakeDestroyDelay;		// The delay for destroying it on Awake.


}

public class Entity : MonoBehaviour
{

		public DestroyDetails desD;
		public level thisLevel;
		public gameManager thisManage;

		void Start ()
		{
				thisLevel.addEntity (this);

		}

		void Awake ()
		{
				
				if (desD.destroyOnAwake) {
						DestroyEntity (desD.awakeDestroyDelay);
				}
		
		}
	
		void DisableChildGameObject (string name)
		{
				// Destroy this child gameobject, this can be called from an Animation Event.
				if (transform.Find (name).gameObject.activeSelf == true)
						transform.Find (name).gameObject.SetActive (false);
		}

		public void DestroyEntity (float i)
		{
				
				Destroy (gameObject, i);

		}

		void OnDestroy ()
		{

				thisLevel.removeEntity (this);

		}


}
