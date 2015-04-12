using UnityEngine;
using System.Collections;

public class shopSlot2 : shopSlot
{

		public override void onClick ()
		{
				AudioManager.thisAM.playerFX.PlayOneShot (clickSound);
				holding.onDrop ();
				GameObject p = (GameObject)Instantiate (holding.phisical.gameObject, transform.position, Quaternion.identity);
				tmp = p.GetComponent<pickups> ();
				tmp.thisLevel = thisM.currentLevel;
				tmp.pickable = true;
				tmp.amount = amount;
		}

}