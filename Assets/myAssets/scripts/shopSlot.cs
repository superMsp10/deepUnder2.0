using UnityEngine;
using System.Collections;

public class shopSlot : UIslot
{
		public Color highlighted;
		public Color normal;
		public shop thisShop;

		void Start ()
		{
		
				thisM = gameManager.thisM;
				if (holding != null)
						changeHolding (holding);
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
	
}

