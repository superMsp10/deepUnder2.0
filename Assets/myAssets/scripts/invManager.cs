using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class invManager : slotCollection
{
		
		private gameManager thismanage;
		public UIslot selected;
		public Holdable empty;
		public Color highlighted;
		public Color normal;
		public int selectedId;
		void Start ()
		{
				thismanage = gameManager.thisM;
				changeNextSlot (empty);
				selectSlot (0);
		}
	
		void Update ()
		{
				if (thismanage.paused) {
						if (Input.GetAxisRaw ("slotChange") > 0) {
								selectSlot (selectedId + 1);
						} else if (Input.GetAxisRaw ("slotChange") < 0) {
								selectSlot (selectedId - 1);
						}
						if (Input.GetButtonDown ("InvSelected") && selected.holding != null) {
								selected.Use ();
						}
				}
				
		}
		public void selectSlot (int i)
		{
				if (i >= 0 && i < slots.Capacity) {
						selectedId = i;
						if (selected != null)
								selected.outline.color = normal;
						selected = slots [i];
						selected.outline.color = highlighted;
				}
		}
}
