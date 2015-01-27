using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class slotCollection : MonoBehaviour
{
		public List<UIslot> slots;
		public void changeNextSlot (Holdable h)
		{

				for (int i = 0; i <  slots.Count; i ++) {

						if (slots [i].holding == null) {
								slots [i].holding = h;
								slots [i].slot.sprite = h.holdUI;
								return;
						}
				}
		}

		public void changeSlot (Holdable h, int i)
		{

				slots [i].holding = h;
				slots [i].slot.sprite = h.holdUI;
			

		}
		
}

