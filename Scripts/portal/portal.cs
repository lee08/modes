using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : wepon {
	public GameObject projectile2;
	public bool shotb= true;
	public bool shoto= true;
	public override void shoot(){
		if (Input.GetMouseButtonDown (0)&&shotb) {
			Instantiate (projectile, shotpoint.position, transform.rotation);
			shotb = false;
			timeBtwShots = startTimeBtwShots;
		}
		if (Input.GetMouseButtonDown (1)&&shoto) {
			Instantiate (projectile2, shotpoint.position, transform.rotation);
			shoto = false;
			timeBtwShots = startTimeBtwShots;
		}
	}

}
