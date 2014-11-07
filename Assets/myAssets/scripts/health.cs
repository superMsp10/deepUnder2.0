using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
		public float HP = 100;
		private float currHP;
		private NetworkManeger thisManage;
		private Animator anim;
		public bool deathDestroy = true;

		// Use this for initialization
		void Start ()
		{
				currHP = HP;
				thisManage = FindObjectOfType<NetworkManeger> ();
				anim = GetComponent<Animator> ();
		}

		//[RPC]
		public void takeDamage (float dmg)
		{
				currHP -= dmg;
				if (currHP <= 0) {
						Die ();
				}
		}

		//[RPC]
		public void Die ()
		{
				
				//	PhotonView pv = GetComponent<PhotonView> ();
				//if (pv.instantiationId == 0) {
				//		Destroy (gameObject);
				//} else {
				//	if (pv.isMine) {
				//thisManage.addChatMassage (this.gameObject.name + " is no longer here with us");
							
				//thisManage.players.Remove (this.gameObject);
				//PhotonNetwork.Destroy (gameObject);
				//thisManage.dead = true;
				//}
				//}
				if (deathDestroy) {
						Destroy (gameObject);
				} else
						gameObject.SetActive (false);

		}




}
