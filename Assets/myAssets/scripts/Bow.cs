using UnityEngine;
using System.Collections;

public class Bow : Holdable
{
		public Mob1 controller;
		public Animator anim;
		public void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
		}


		public override void  onUse ()
		{
				anim.SetTrigger ("Attack");
				thisManage = gameManager.thisM;
				if (thisManage.myPlayer != null)
						Instantiate (gameObject, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
		
		}
		public override void  onSelect ()
		{
				Debug.Log ("hifrom bow select");
		
		}
		public override void  onDeselect ()
		{
				Debug.Log ("hifrom bow de select");
		
		}
		public override void  onPickup ()
		{
				thisManage = gameManager.thisM;
				Debug.Log ("hifrom on pickup");
				if (thisManage.myPlayer != null) {
						GameObject g = (GameObject)Instantiate (gameObject, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);

						g.transform.SetParent (controller.weaponHand.transform);
				}
		
		}
	
		public override void  onDrop ()
		{
				Debug.Log ("hifrom on drop");
		
		}


}

