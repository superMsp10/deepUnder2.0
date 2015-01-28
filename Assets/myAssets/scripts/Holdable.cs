using UnityEngine;
using System.Collections;

public class Holdable : MonoBehaviour
{

		public Sprite holdUI;

		

		public virtual void  onUse ()
		{
				Debug.Log ("hifrom holdable");

		}
}
