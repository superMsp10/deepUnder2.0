using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class invManager : MonoBehaviour
{

		private gameManager thismanage;
		public List<Image>slots;
		public Sprite empty;
		void Start ()
		{
				thismanage = gameManager.thisM;
				foreach (Image s in slots) {
						s.sprite = empty;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
