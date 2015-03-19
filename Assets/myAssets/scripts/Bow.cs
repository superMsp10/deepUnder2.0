using UnityEngine;
using System.Collections;

public class Bow : Holdable
{
		public Mob1 controller;
		public Animator anim;
		public GameObject dummy;

		public void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
				dummy.SetActive (false);
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


}

