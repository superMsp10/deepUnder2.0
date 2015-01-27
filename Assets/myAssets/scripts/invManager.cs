using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class invManager : slotCollection
{
		
		private gameManager thismanage;
		
		public Holdable empty;
		void Start ()
		{
				thismanage = gameManager.thisM;
				changeNextSlot (empty);
		}
	
		


}
