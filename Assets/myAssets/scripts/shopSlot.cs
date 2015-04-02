using UnityEngine;
using System.Collections;

public class shopSlot : UIslot
{
		public Color highlighted;
		public Color normal;
		public shop thisShop;
		public Holdable price;
		public int priceAmount;


		void Start ()
		{
		
				thisM = gameManager.thisM;
				if (holding != null)
						changeHolding (holding, amount, false);
				selected = false;

		}
		public virtual void onClick ()
		{
				selected = !selected;
				if (selected) {
						outline.color = highlighted;
						if (holding != null) {
								thisShop.description.text = holding.description;
						}
				}
				if (!selected) {
						outline.color = normal;
						thisShop.description.text = thisShop.descriptionDefault;
				}
		}


		public void onBuy (int button)
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

