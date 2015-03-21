using UnityEngine;
using System.Collections;

public class Bow : Weapon
{
		public GameObject arrow;
		public bool rotate;
		
		public float force;
		public Vector2 dir;
		
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
				dir = controller.attackArea.transform.position;
				Vector2 pos = new Vector2 (controller.weaponHand.transform.position.x, controller.weaponHand.transform.position.y);
						
				GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
				Vector2 dir2 = dir - pos;
				float distance = dir2.magnitude;
				Vector2 direction = dir2 / distance;
			
				g.rigidbody2D.AddForce (dir2 * force);

			
	
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
