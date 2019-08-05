using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepon : MonoBehaviour {

	public float offset;
	// Use this for initialization
	public GameObject projectile;
	public Transform shotpoint;

	public float timeBtwShots;
	public float startTimeBtwShots;

	public Rigidbody2D rb;

	void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,rotZ+offset);
		if (timeBtwShots <= 0) {
			shoot ();
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}

	public virtual void shoot(){
		if (Input.GetMouseButtonDown (0)) {

			if (projectile != null) {
				Instantiate (projectile, shotpoint.position, transform.rotation);
			}
			timeBtwShots = startTimeBtwShots;
		}
	}
}
