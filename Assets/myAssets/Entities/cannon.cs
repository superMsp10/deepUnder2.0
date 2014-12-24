using UnityEngine;
using System.Collections;

public class cannon : Entity
{
		public Transform target;
		public LayerMask shootWhat;
		public Transform nuzzle;
		public float rad;
		public float power;

		public void shoot ()
		{

				transform.LookAt (target);
				Collider2D[] col = Physics2D.OverlapCircleAll (target.position, power, shootWhat);
				foreach (Collider2D c in col) {

						c.rigidbody2D.AddForce (transform.forward * power);
				}
		}

		public void shoot (Transform target)
		{

				transform.LookAt (target);
				Collider2D[] col = Physics2D.OverlapCircleAll (target.position, power, shootWhat);
				foreach (Collider2D c in col) {
			
						c.rigidbody2D.AddForce (transform.forward * power);
				}
		}

		public void shoot (Transform target, float power)
		{
		
				transform.LookAt (target);
				Collider2D[] col = Physics2D.OverlapCircleAll (target.position, power, shootWhat);
				foreach (Collider2D c in col) {
			
						c.rigidbody2D.AddForce (transform.forward * power);
				}
		}
}

