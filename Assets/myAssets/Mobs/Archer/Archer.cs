using UnityEngine;
using System.Collections;

public class Archer : Enemy
{
		public bow_Mob bow;

		void Start ()
		{
	
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				rigidbody2D.centerOfMass = centerOfMass;
				thisAnim = GetComponent<Animator> ();
				checkNecesseries ();
	
		}


		protected override void checkNecesseries ()
		{
		
				if (thisLevel == null)
						Debug.LogError ("no Level referenced for this entity: " + gameObject.name);
		
				if (thisAnim == null && animated) {
						Debug.LogError ("no animator is provided");
				}
				if (groundCheck == null)
						Debug.Log ("no feets included");
				bodyParts = GetComponentsInChildren<BodyPart> ();
				foreach (BodyPart b in bodyParts) {
						b.thisLevel = thisLevel;
				}
				healthbar.maxValue = thisAttributes.maxHP;
				healthbar.value = thisAttributes.HP;
		
		}

		protected override void TargetSight ()
		{



				if (target != null) {

						if (Vector2.Distance (target.transform.position, transform.position) > sight) {
								target = null;
								if (despawnWithDistance) {
										gameObject.SetActive (false);
								}
								goto end;
						}
						if (Vector2.Distance (target.transform.position, transform.position)
								> thisAttributes.optTargetRange) {
								moveAi ();
								attacking = false;
						} else {
								checkLooking ();

								attacking = true;
								bow.target = target;
								bow.attack ();
						}
						
				} else {
						selectTarget ();
						attacking = false;
						thisAttributes.moving = false;
				}
				end:
				;

		}
		public override  void die ()
		{
				Resource r = GetComponent<Resource> ();
				r.dropMadeOf ();
				Destroy (gameObject);
		
		}


}
