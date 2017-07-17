using UnityEngine;
using System.Collections;

public class Healing : Holdable
{
		public ParticleSystem healingEffect;

		public	int healAmount = 60;
		public AudioClip sound;
		protected	GameObject weaponIns ;

		public override bool  onUse ()
		{
				thisManage = gameManager.thisM;
	
				Tarsc palyer = thisManage.myPlayer.GetComponent<Tarsc> ();
				AudioManager.thisAM.weapons.PlayOneShot (sound);
				if (palyer.thisAttributes.maxHP > (palyer.thisAttributes.HP + healAmount)) {
						palyer.thisAttributes.HP += healAmount;
				} else {
					
						palyer.thisAttributes.HP = palyer.thisAttributes.maxHP;
				}
				palyer.healthbar.value = palyer.thisAttributes.HP;
				if (healingEffect != null) {
						healingEffect.Play ();
						Invoke ("resetParticles", 4f);
				}
				return true;
		
		}
		public override void  onSelect ()
		{
				if (weaponIns == null) {
						insModel ();
				} 

				weaponIns.SetActive (true);
		
		}
		public override void  onDeselect ()
		{
				if (weaponIns == null) {
						insModel ();
				} 
				weaponIns.SetActive (false);
		
		}
		public override void  onPickup ()
		{
				thisManage = gameManager.thisM;
			
		
		}
	
		public override void  onDrop ()
		{
		}


		public void insModel ()
		{
				GameObject player = thisManage.myPlayer;
				weaponIns = (GameObject)Instantiate (gameObject, player.transform.position, Quaternion.identity);
				weaponIns.transform.SetParent (player.transform);
				weaponIns.transform.Translate (0, 10, 0);
				GameObject partiicleChild = weaponIns.transform.Find ("healing").gameObject;
				healingEffect = partiicleChild.GetComponent<ParticleSystem> ();
				
		}

		void resetParticles ()
		{
				if (healingEffect != null) {
						healingEffect.Stop ();
						Destroy (weaponIns);
				}
		}
	
}

