using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
		public Holdable holding;
		public Image slot;

		public void changeHolding (Holdable h)
		{
				holding = h;
				slot.sprite = h.holdUI;
		}
}

