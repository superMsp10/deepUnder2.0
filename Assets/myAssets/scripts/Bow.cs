using UnityEngine;
using System.Collections;

public class Bow : Weapon
{
		public GameObject arrow;
		public Mob1 player;
		public bool rotate;
		public float min;
		public float max;
		
		public void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
				player = thisManage.myPlayer.GetComponent<Mob1> ();

		}
	

		void Update ()
		{
				if (rotate) {
						Vector3 mousePos = Input.mousePosition * -1;
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, mousePos.y / Mathf.PI);


				}

		}

		public override void  onUse ()
		{
				thisManage = gameManager.thisM;
				player = thisManage.myPlayer.GetComponent<Mob1> ();

				if (thisManage.myPlayer != null) {
				
						GameObject g = (GameObject)Instantiate (arrow, player.transform.position, Quaternion.identity);
						

						g.rigidbody2D.velocity.Set (10000, 1000);
						Debug.Log (g.rigidbody2D.velocity);
				}
	
		}


		public override void  onSelect ()
		{
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = true;
				if (weaponIns == null) {
						insWeapon ();
				} 
				weaponIns.SetActive (true);
				rotate = true;
				
		}

		public override void  onDeselect ()
		{
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = false;
				if (weaponIns == null) {
						insWeapon ();
				} 
				weaponIns.SetActive (false);
				rotate = false;
				
		
		}

		void insWeapon ()
		{
				if (thisManage.myPlayer != null) {
						weaponIns = (GameObject)Instantiate (gameObject, controller.weaponHand.transform.position, controller.weaponHand.transform.rotation);
			
						weaponIns.transform.SetParent (controller.weaponHand.transform);

				}
		}
}
