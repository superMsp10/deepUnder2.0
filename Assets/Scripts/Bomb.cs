using UnityEngine;
using System.Collections;


public class Bomb : Holdable
{
	public float bombRadius = 10f;			// Radius within which enemies are killed.
	public float bombForce = 100f;			// Force that enemies are thrown from the blast.
	public AudioClip boom;					// Audioclip of explosion.
	public AudioClip fuse;					// Audioclip of fuse.
	public float fuseTime = 1.5f;
	public GameObject explosion;			// Prefab of explosion effect.
	public LayerMask whatExplode;
	public float dmg;
	public ParticleSystem particleIns;
	public static ParticleSystem explosionFX;		// Reference to the particle system of the explosion effect.


		
	public override bool  onUse ()
	{
		thisManage = gameManager.thisM;

		if (thisManage.myPlayer != null) {
			Instantiate (gameObject, gameManager.thisM.myPlayer.transform.position, Quaternion.identity);
			return true;
		}
		return false;

	}

	new void Start ()
	{
		thisManage = gameManager.thisM;
		// If the bomb has no parent, it has been laid by the player and should detonate.
		if (transform.root == transform)
			StartCoroutine (BombDetonation ());
		if (explosionFX == null) {
						 
			GameObject g = (GameObject)Instantiate (particleIns.gameObject);
			explosionFX = g.GetComponent<ParticleSystem>();

		}
	}


	IEnumerator BombDetonation ()
	{
		// Play the fuse audioclip.
		AudioSource.PlayClipAtPoint (fuse, transform.position, AudioManager.thisAM.weapons.volume);

		// Wait for 2 seconds.
		yield return new WaitForSeconds (fuseTime);

		// Explode the bomb.
		Explode ();
	}


	public void Explode ()
	{
		
			

		// Find all the colliders on the Enemies layer within the bombRadius.
		Collider2D[] enemies = Physics2D.OverlapCircleAll (transform.position, bombRadius, whatExplode);

		// For each collider...
		foreach (Collider2D en in enemies) {
			// Check if it has a rigidbody (since there is only one per enemy, on the parent).
			if (en.gameObject.GetInstanceID () != gameObject.GetInstanceID ()) {
								
					
				Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
				Mob1 mab = en.GetComponent<Mob1> ();
				if (rb != null) {
					// Find the Enemy script and set the enemy's health to zero.
								
					float distanceForce;
					// Find a vector from the bomb to the enemy.
					Vector3 deltaPos = rb.transform.position - transform.position;
					if (Vector2.Distance (rb.transform.position, transform.position) < bombRadius) {
						distanceForce = bombRadius - Vector2.Distance (rb.transform.position, transform.position);
					} else {
						distanceForce = 0f;

					}
					// Apply a force in this direction with a magnitude of bombForce.
					Vector3 force = deltaPos.normalized * bombForce * distanceForce;
					rb.AddForce (force, ForceMode2D.Impulse);
					if (mab != null) {
						mab.takeDmg (dmg * distanceForce);
					}
				}
								
			}	
		}
		// Set the explosion effect's position to the bomb's position and play the particle system.
		explosionFX.transform.position = transform.position;
		explosionFX.Play ();

		// Instantiate the explosion prefab.
		Destroy (Instantiate (explosion, transform.position, Quaternion.identity), 0.01f);

		// Play the explosion sound effect.
		AudioSource.PlayClipAtPoint (boom, transform.position, AudioManager.thisAM.weapons.volume);

		// Destroy the bomb.
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "teleport") {
			Teleport teleSpot = other.GetComponent<Teleport> ();
			teleSpot.teleport (gameObject);
			
		}
		if (other.gameObject.tag == "boost") {
			collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
			if (thisBoost == null)
				Debug.LogError ("no collision boost script attached");
			/*	float thisX = rigidbody2D.velocity.x / 2;
			float thisY = rigidbody2D.velocity.y / 2;
			
			Vector2 force = new Vector2 (thisX +((thisBoost.multiX) * thisBoost.boostAmount)
			                             , thisY + ((-thisBoost.multiY) * thisBoost.boostAmount));
			rigidbody2D.AddForceAtPosition (force, transform.position);

*/
			thisBoost.boost (GetComponent<Rigidbody2D>());
		}
		
		
			
		
			

	}
}
