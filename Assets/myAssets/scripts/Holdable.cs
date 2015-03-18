using UnityEngine;
using System.Collections;

public class Holdable : MonoBehaviour
{

		public Sprite holdUI;
		public gameManager thisManage;
		public pickups phisical;
		public void Start ()
		{
				thisManage = gameManager.thisM;
		}

		

		public virtual void  onUse ()
		{
				Debug.Log ("hifrom holdable");

		}
}
