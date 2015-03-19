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
						if (slots [i].holding == null) {
								Debug.Log ("hi");

								if (amount > h.stackSize) {
										returning = amount - h.stackSize;
								} else {
										slots [i].changeHolding (h, amount);
										return 0;
								}
						} else if (slots [i].holding == h && slots [i].amount < h.stackSize) {


						}
				}

				return 0;
		}


		public void changeSlot (Holdable h, int i)
		{

				slots [i].changeHolding (h);
			

		}

}

