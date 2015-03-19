using UnityEngine;
using System.Collections;

public class Holdable : MonoBehaviour
{

		public Sprite holdUI;
		public gameManager thisManage;
		public pickups phisical;
		public int stackSize;
		public void Start ()
		{
				thisManage = gameManager.thisM;
		}

		

		public virtual void  onUse ()
		{
				Debug.Log ("hifrom holdable");

		}
		public virtual void  onSelect ()
		{
				Debug.Log ("hifrom select");
		
		}
		public virtual void  onDeselect ()
		{
				Debug.Log ("hifrom de select");
		
		}


}
