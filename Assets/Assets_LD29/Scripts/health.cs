using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {
	public float HP = 100;
	private float currHP;
	 public GameObject spawnPoint;
	public float damage = 10;


	public bool respawn = false;


	// Use this for initialization
	void Start () {
		currHP = HP;

	}


	public void takeDamage (float dmg) {
		currHP -= dmg;
		if(currHP<=0){
			Die();
		}
	}

	void Die(){
		if (respawn) {
						this.transform.position = spawnPoint.transform.position;
						currHP = HP;
				} else {
			this.gameObject.SetActive(false);

				}


	}




}
