using UnityEngine;
using System.Collections;

public class Holdable : MonoBehaviour
{

		public Sprite holdUI;
		public gameManager thisManage;
		public pickups phisical;
		public int stackSize;
		public bool weapon = false;
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
		public virtual void  onPickup ()
		{
				Debug.Log ("hifrom on pickup");
		
		}

		public virtual void  onDrop ()
		{
				Debug.Log ("hifrom on drop");
		
		}


}
