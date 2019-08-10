using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterjet : wepon {
	public float thrust;
	public float thrustx;
	// Use this for initialization
	public override void shoot(){
		if (Input.GetMouseButton (0)) {
			Instantiate (projectile, shotpoint.position, transform.rotation);
			timeBtwShots = startTimeBtwShots;
			Vector3 dir = shotpoint.position - transform.position;
			rb.AddForce (new Vector2(dir.x*thrustx,dir.y*thrust));
		}
	}
}
