using UnityEngine;
using System.Collections;

public class playerShooter : MonoBehaviour
{
	
		private float fireRate = 2f;
		private float coolDown = 0;
		private NetworkManeger thisManage;
		private effectsManager thisFX;
		private PhotonView effectView;
		public float damage = 60;
		private bool invDis = false;
		// Use this for initialization
		void Start ()
		{
				thisManage = FindObjectOfType<NetworkManeger> ();
				thisFX = FindObjectOfType<effectsManager> ();
				effectView = thisFX.GetComponent<PhotonView> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (thisManage.inGame) {
						coolDown -= Time.deltaTime;
						if (Input.GetButton ("Fire1")) {
								fire ();
						}
				}
		}

		void inInv (bool val)
		{
				invDis = val;
		}

		void fire ()
		{
				if (coolDown > 0 || invDis) {
						return;
				}
				
				Ray ray = new Ray (this.transform.FindChild ("soldier").FindChild ("Hips").FindChild ("Camera").transform.position,
		                   this.transform.FindChild ("soldier").FindChild ("Hips").FindChild ("Camera")
		                   .transform.forward);
				Transform hitThing;
				Vector3 hitPoint;
				bool human = false;
				hitThing = getHitInfo (ray, out hitPoint);
				string PlayerName = PhotonNetwork.player.name;
		  
				if (hitThing != null) {
						health h = hitThing.GetComponent<health> ();
						if (h != null) {
								damage += 10;
								h.GetComponent<PhotonView> ().RPC ("takeDamage", PhotonTargets.All, damage);
								ObjectPushBack ((int)(damage / 5), hitThing.rigidbody, ray.direction);
								if (hitThing.tag == "Player")
										human = true;

								thisManage.addChatMassage (PlayerName + " has hit "
										+ hitThing.name + " for " + damage + " points, " + PlayerName + "'s damage increased by 10 points");
									
						} else {
								damage -= 5;
								thisManage.addChatMassage (PlayerName + " has missed and hit "
										+ hitThing.name + ", " + PlayerName + "'s damage fell by 5 points");
						}
					
				} else {
						hitPoint = (this.transform.FindChild ("soldier").FindChild ("Hips")
			            .FindChild ("Camera").transform.position + (this.transform.FindChild ("soldier")
			            .FindChild ("Hips").FindChild ("Camera").transform.forward * 100));
						damage -= 50;
						thisManage.addChatMassage (PlayerName + " missed horribly." + PlayerName
								+ "'s damage tumbled into space by 50 points, no way to get those back without hack");
			
				}

		
				effectView.RPC ("SniperLaser", PhotonTargets.All,
		                this.transform.FindChild ("soldier").FindChild ("Hips").FindChild ("Camera")
		                .transform.position, hitPoint, human);
				coolDown = fireRate;
		}
	
		void ObjectPushBack (int pushPower, Rigidbody body, Vector3 direction)
		{
				// no rigidbody
				if (body == null || body.isKinematic)
						return;
			
				
			
			
				// Apply the push
				body.velocity = direction * pushPower;

		}

		Transform getHitInfo (Ray ray, out Vector3 hitPoint)
		{
				RaycastHit[] hits = Physics.RaycastAll (ray);
				Transform closestHit = null;
				hitPoint = Vector3.zero;
				float distance = 0;
				foreach (RaycastHit hit in hits) {
						if (hit.transform != this.transform && (closestHit == null || hit.distance < distance)) {
								closestHit = hit.transform;
								distance = hit.distance;
								hitPoint = hit.point;
						}
				}
				return closestHit;
		}
}
