using UnityEngine;
using System.Collections;

public class Weapon : Holdable
{
		public Mob1 controller;
		public Animator anim;
		protected	GameObject weaponIns ;

		new  void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
		}


		public override bool  onUse ()
		{
				anim.SetTrigger ("Attack");
				thisManage = gameManager.thisM;
			
				return true;
		
		}
		public override void  onSelect ()
		{
				controller.attacking = true;
				weaponIns.SetActive (true);
		
		}
		public override void  onDeselect ()
		{
				controller.attacking = false;
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
				controller.attacking = false;
				Destroy (weaponIns);
		}

		public void insModel ()
		{

				weaponIns = (GameObject)Instantiate (gameObject, controller.weaponHand.transform.position, Quaternion.identity);
		
				weaponIns.transform.SetParent (controller.weaponHand.transform);
				weaponIns.transform.rotation = new Quaternion (0, 0, 0, 0);
				weaponIns.transform.localScale = gameObject.transform.localScale;
		}

}

