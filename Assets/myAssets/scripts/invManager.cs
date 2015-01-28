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
				selected = slots [0];
		}
	
		void Update ()
		{
				if (Input.GetButtonDown ("InvSelected")) {
						selected.Use ();
				}
		}


}
