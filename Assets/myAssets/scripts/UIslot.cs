using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
		public Holdable holding;
		public Image slot;
		public Sprite empty;

		

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
}

