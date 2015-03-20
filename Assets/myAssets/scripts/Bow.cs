using UnityEngine;
using System.Collections;

public class Bow : Weapon
{
		public GameObject arrow;
		public bool rotate;
		public float min;
		public float max;
		
		public void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
	

		}
	

		void Update ()
		{
				if (rotate) {
						Vector3 mousePos = thisManage.currCamera.ScreenToWorldPoint (Input.mousePosition);
						Vector3 thisPos = transform.position;
						// Get Angle in Radians
						float AngleRad = Mathf.Atan2 (mousePos.y - thisPos.y, mousePos.x - thisPos.x);
						// Get Angle in Degrees
						float AngleDeg = (180 / Mathf.PI) * AngleRad;
						// Rotate Object
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, AngleDeg);
				}
		}

		public override void  onUse ()
		{
				thisManage = gameManager.thisM;
				if (thisManage.myPlayer != null) {
				
						GameObject g = (GameObject)Instantiate (arrow, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
						

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
