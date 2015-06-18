using UnityEngine;
using System.Collections;

public class Healing : Holdable
{

		int healAmount = 5;
		protected	GameObject weaponIns ;

		public override bool  onUse ()
		{
				thisManage = gameManager.thisM;
		
				return true;
		
		}
		public override void  onSelect ()
		{
				weaponIns.SetActive (true);
		
		}
		public override void  onDeselect ()
		{
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
				GameObject player = thisManage.myPlayer;
				weaponIns = (GameObject)Instantiate (gameObject, player.transform.position, Quaternion.identity);
				weaponIns.transform.SetParent (player.transform);
				weaponIns.transform.Translate (0, 10, 0);
				
		}

	
}

