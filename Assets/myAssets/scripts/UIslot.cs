using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
		public Holdable holding;
		public Image slot;
		public Sprite empty;
		public Image outline;
		gameManager thisM;
		Vector2 playerPos;
		pickups tmp;

		void Start ()
		{

				thisM = gameManager.thisM;
		}


		

		public void changeHolding (Holdable h)
		{
				if (h == null) {
						slot.sprite = empty;
						holding = null;
				} else {
						holding = h;
						
						slot.sprite = h.holdUI;
						
				}
		}

		public void Use ()
		{
				holding.onUse ();
				changeHolding (null);
		}

		public void onClick ()
		{
				if (holding != null) {
						if (thisM.myPlayer != null) {
								playerPos = thisM.myPlayer.transform.position;
								
								GameObject p = (GameObject)Instantiate (holding.phisical.gameObject, playerPos, Quaternion.identity);
								tmp = p.GetComponent<pickups> ();
								tmp.thisLevel = thisM.currentLevel;
								tmp.pickable = false;
								Invoke ("resetPickable", 5);
								changeHolding (null);
						}
				}
		}

		void resetPickable ()
		{
				tmp.pickable = true;
		
		}
}

