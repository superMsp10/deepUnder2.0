using UnityEngine;
using System.Collections;

public class questManager : MonoBehaviour
{
		public gameManager thisM;
		public static questManager thisQuest;
		void Awake ()
		{
				if (thisQuest == null)
						thisQuest = this;
		
		
		}
	
		void Start ()
		{
	
	
		}

}