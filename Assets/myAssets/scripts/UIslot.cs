using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIslot : MonoBehaviour
{
		public Holdable holding;
		public Image slot;
		public Sprite empty;
		public Image outline;


		

		public void changeHolding (Holdable h)
		{
				if (h == null) {
						slot.sprite = empty;
						holding = null;
				} else {
						holding = h;
						holding.phisical.thisLevel = gameManager.thisM.currentLevel;
						slot.sprite = h.holdUI;
						Debug.Log ("hi");
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
						if (gameManager.thisM.myPlayer != null)
								Instantiate (holding.phisical, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
						holding = null;
				}
		}
}

