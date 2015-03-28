using UnityEngine;
using System.Collections;

public class Bow : Weapon
{
		public GameObject arrow;
		public bool rotate = true;
		public AudioClip shoot;

		public float force;
		protected Vector3 dir;
		public bool recharging = false;
		public float rof;
		public bool intialize;
		protected AudioSource thisAudio;
		

	
		new void Start ()
		{
				thisManage = gameManager.thisM;
				anim = GetComponent<Animator > ();
				thisAudio = AudioManager.thisAM.weapons;
		}
	
		public virtual void shootSound ()
		{
				if (thisAudio == null) {

						thisAudio = AudioManager.thisAM.weapons;
				}
				thisAudio.PlayOneShot (shoot);
		
		}
		void Update ()
		{

				if (rotate) {
						Vector3 mousePos = Input.mousePosition * -1;
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, mousePos.y / Mathf.PI);


				}

		}

		public override bool  onUse ()
		{
				if (!recharging) {
						shootSound ();
						Vector3 mousePos = Input.mousePosition * -1;
						controller.weaponHand.transform.parent.rotation = Quaternion.Euler (0, 0, mousePos.y / Mathf.PI);
						dir = controller.attackArea.transform.position;

						int offSet;
						if (controller.turnR) {
								offSet = 2;
						} else {
								offSet = -2;
						}

						Vector3 pos = new Vector3 (controller.weaponHand.transform.position.x + offSet, controller.weaponHand.transform.position.y);
						
						GameObject g = (GameObject)Instantiate (arrow, pos, Quaternion.identity);
					
						g.transform.rotation = controller.weaponHand.transform.parent.rotation;
						if (controller.turnR) {
								g.transform.rotation = Quaternion.Inverse (g.transform.rotation);
						} 
						
							
						if (intialize) {
								g.GetComponent<Entity> ().thisLevel = thisManage.currentLevel;
						}
						Vector3 dir2 = dir - pos;

						g.rigidbody2D.AddForce (dir2 * force);
						controller.rigidbody2D.AddForce (-dir2 * (force / controller.rigidbody2D.mass));
						recharging = true;
						Invoke ("resetShoot", rof);
						return true;
				}
				return false;
		}


		public override void  onSelect ()
		{
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = true;
				if (weaponIns == null) {
						insModel ();
				} 
			

				weaponIns.SetActive (true);
				rotate = true;
				
		}

		public override void  onDeselect ()
		{
				thisManage.myPlayer.GetComponent<Mob1> ().attacking = false;
				if (weaponIns == null) {
						insModel ();
				} 
				weaponIns.SetActive (false);
				rotate = false;
				
		
		}

		public void resetShoot ()
		{
				recharging = false;
		}

		
}
