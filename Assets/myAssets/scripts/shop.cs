using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shop : slotCollection
{

		public Text description;
		public string descriptionDefault = "Click on the item to select it for desciption, press buy to buy one of that object and press buy * 5 to buy 5 of that item. Click on the item again if you want to deselect.";
		public void onBuy (int button)
		{
				foreach (UIslot s in slots) {
						shopSlot slot = s as shopSlot;
						if (slot.selected) {
								for (int i = button; i>0; i--) {
										int am = player.takeItem (slot.price, slot.priceAmount);
										if (slot.price != null && am == 0) {
												slot.onBuy (am);

										}
								}
						}

				}
		
		
		}
}

