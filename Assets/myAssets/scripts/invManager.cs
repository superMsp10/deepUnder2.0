using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class invManager : MonoBehaviour
{

		private gameManager thismanage;
		public List<Image>slots;
		public Sprite empty;
		public List <Holdable> inv;
		void Start ()
		{
				thismanage = gameManager.thisM;
				
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void changeSlot (Holdable h)
		{
				for (int i = 0; i <  inv.Count; i ++) {

						if (inv [i] == null) {
								inv [i] = h;
								slots [i].sprite = h.holdUI;
								return;
						}
				}
		}
}
