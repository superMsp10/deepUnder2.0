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

		

		public virtual bool  onUse ()
		{
				return false;

		}
		public virtual void  onSelect ()
		{

		}
		public virtual void  onDeselect ()
		{

		}
		public virtual void  onPickup ()
		{

		}

		public virtual void  onDrop ()
		{

		}


}
