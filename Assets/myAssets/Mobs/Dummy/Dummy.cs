using UnityEngine;
using System.Collections;

public class Dummy : Enemy
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
		
				bool ground = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatGround);
		
				if (!grounded && ground) {
						landed = true;
						grounded = true;
			
			
				} else if (!ground) {
						grounded = false;
						landed = false;
			
			
				} else {
						landed = false;
				}
	
		}
}
