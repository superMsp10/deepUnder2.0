using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class invManager : slotCollection
{
		
		private gameManager thismanage;
		public UIslot selected;
		public Holdable empty;
		void Start ()
		{
				thismanage = gameManager.thisM;
				changeNextSlot (empty);
				selectSlot (0);
		}
	
		void Update ()
		{
				if (thismanage.paused) {
						if (Input.GetButtonDown ("InvSelected") && selected.holding != null) {
								selected.Use ();
						}
				}
				
		}
		public void selectSlot (int i)
		{
		
				selected = slots [i];

		}

}
