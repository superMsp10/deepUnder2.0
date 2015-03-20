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
						// Get Angle in Radians
						float AngleRad = Mathf.Atan2 (mousePos.y - transform.position.y, mousePos.x - transform.position.x);
						// Get Angle in Degrees
						float AngleDeg = (180 / Mathf.PI) * AngleRad;
						// Rotate Object
						transform.rotation = Quaternion.Euler (0, 0, Mathf.Clamp (AngleDeg * 5, min, max));
				}
		}

		public override void  onUse ()
		{
				thisManage = gameManager.thisM;
				if (thisManage.myPlayer != null)
						Instantiate (arrow, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
		
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
