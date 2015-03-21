using UnityEngine;
using System.Collections;

public class Bow : Weapon
{
		public GameObject arrow;
		public bool rotate;
		public float min;
		public float max;
		public float force;
		
		public void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();

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
				Vector2 mousePos = Input.mousePosition * -1;
				controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, mousePos.y / Mathf.PI);
				Vector2 pos = new Vector2 (controller.weaponHand.transform.position.x, controller.weaponHand.transform.position.y);
						
				GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
				Vector2 dir = new Vector2 (pos.x - g.transform.position.x, pos.y - g.transform.position.y);
				if (controller.turnR) {
						g.rigidbody2D.AddForce (dir * force * 100);

				} else {
						g.rigidbody2D.AddForce (dir * -force * 100);
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
