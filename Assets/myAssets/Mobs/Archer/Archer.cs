using UnityEngine;
using System.Collections;

public class Archer : Enemy
{
		public bow_Mob bow;



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
				if (dropMadeOF) {
						Resource r = GetComponent<Resource> ();
						r.dropMadeOf ();
				}
				Destroy (gameObject);
		
		}


}
