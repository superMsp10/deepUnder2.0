using UnityEngine;
using System.Collections;

public class Weapon : Holdable
{
		public Mob1 controller;
		public Animator anim;
		protected	GameObject weaponIns ;
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
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = true;
				weaponIns.SetActive (true);
		
		}
		public override void  onDeselect ()
		{
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = false;
				weaponIns.SetActive (false);


		}
		public override void  onPickup ()
		{
				thisManage = gameManager.thisM;
				if (thisManage.myPlayer != null) {
						weaponIns = (GameObject)Instantiate (gameObject, controller.weaponHand.transform.position, controller.weaponHand.transform.rotation);

						weaponIns.transform.SetParent (controller.weaponHand.transform);
				}
		
		}
	
		public override void  onDrop ()
		{
				Destroy (weaponIns);
		}


}

