using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
		public Holdable holding;
		public Image slot;
		public Sprite empty;
		public Image outline;
		public int amount;
		public Text amountText;
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
						amount = 0;
						amountText.text = "";
				} else {
						
						holding = h;
						holding.onPickup ();
						slot.sprite = h.holdUI;
						amount = 1;
						amountText.text = "1";
				}
		}

		public void changeHolding (Holdable h, int amounts)
		{
				holding = h;
				holding.onPickup ();

				amount = amounts;
				slot.sprite = h.holdUI;
				amountText.text = amount.ToString ();
				
		}

		public void Use ()
		{
				holding.onUse ();
				amount -= 1;
				amountText.text = amount.ToString ();

				if (amount <= 0) {
						changeHolding (null);
						amountText.text = "";
				}
		}

		public void onClick ()
		{
				if (holding != null) {
						holding.onDrop ();
						if (thisM.myPlayer != null) {
								playerPos = thisM.myPlayer.transform.position;
								
								GameObject p = (GameObject)Instantiate (holding.phisical.gameObject, playerPos, Quaternion.identity);
								tmp = p.GetComponent<pickups> ();
								tmp.thisLevel = thisM.currentLevel;
								tmp.pickable = false;
								tmp.amount = amount;
								Invoke ("resetPickable", tmp.resetPickup);
								changeHolding (null);
						}
				}
		}

		public void onSelect ()
		{
				if (holding != null)
						holding.onSelect ();



		}

		public void onDeselect ()
		{
				if (holding != null)
						holding.onDeselect ();

		}
		void resetPickable ()
		{
				tmp.pickable = true;
		
		}
}

