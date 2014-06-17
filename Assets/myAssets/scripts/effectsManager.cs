using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class effectsManager : MonoBehaviour
{

		public AudioClip SniperShot;
		public AudioClip SniperShothit;
		public AudioClip hitHuman;
		public Material lineMat;
		private Vector3 endPos;
		private List <GameObject> shotEffects;
		private GameObject sniperFX;
		private LineRenderer lineren;

		void Start ()
		{
				shotEffects = new List<GameObject> ();


		}

		[RPC]
		void SniperLaser (Vector3 startPos, Vector3 endPos, bool human)
		{
				this.endPos = endPos;
				sniperFX = (Instantiate (this.transform.FindChild ("SniperBulletEffect"))as Transform).gameObject;
				shotEffects.Add (sniperFX);		
				lineren = sniperFX.transform.FindChild ("lineEffect").GetComponent <LineRenderer> ();
				lineren.SetPosition (0, startPos);
				lineren.SetPosition (1, endPos);
				AudioSource.PlayClipAtPoint (SniperShot, startPos);
				AudioSource.PlayClipAtPoint (SniperShothit, endPos);
				if(human)
				AudioSource.PlayClipAtPoint (hitHuman, endPos);
				
				
				
		}
		
		void Update(){
		if (shotEffects.Count > 5) {
			Destroy (shotEffects [0]);
			shotEffects.RemoveAt (0);
				}



		}
	
}
