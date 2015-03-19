using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class slotCollection : MonoBehaviour
{
		public List<UIslot> slots;

		public bool changeNextSlot (Holdable h)
		{

				for (int i = 0; i <  slots.Count; i ++) {

						if (slots [i].holding == null) {
								slots [i].changeHolding (h);
								return true;
						}
				}
				return false;
		}

		public int addHoldable (Holdable h, int amount)
		{
				int returning = 0;
				for (int i = 0; i <  slots.Count; i ++) {

						if (slots [i].holding == null || slots [i].holding == h && slots [i].amount < h.stackSize) {
								int left = slots [i].amount + amount;
								if (left > h.stackSize) {
										amount = left - h.stackSize;
										slots [i].changeHolding (h, h.stackSize);
								} else {
										slots [i].changeHolding (h, left);
										return 0; 
										amount = 0;
								}
						}
						/*	if (slots [i].holding == null) {
							

								if (amount > h.stackSize) {
										slots [i].changeHolding (h, h.stackSize);
										amount = amount - h.stackSize;

								} else {
										slots [i].changeHolding (h, amount);
										return 0;

								}
						} else if (slots [i].holding == h && slots [i].amount < h.stackSize) {
								int space = h.stackSize - slots [i].amount;

								slots [i].changeHolding (h, amount + slots [i].amount);

						}
				}*/

				}
				return returning;
		}

		public void changeSlot (Holdable h, int i)
		{

				slots [i].changeHolding (h);
			

		}

}

