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


		public override bool  onUse ()
		{
				anim.SetTrigger ("Attack");
				thisManage = gameManager.thisM;
				if (thisManage.myPlayer != null)
						Instantiate (gameObject, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
				return true;
		
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
						insModel ();
				}
		
		}
	
		public override void  onDrop ()
		{
				Destroy (weaponIns);
		}

		public void insModel ()
		{

				weaponIns = (GameObject)Instantiate (gameObject, controller.weaponHand.transform.position, Quaternion.identity);
		
				weaponIns.transform.SetParent (controller.weaponHand.transform);
				weaponIns.transform.rotation = new Quaternion (0, 0, 0, 0);
		}

}

