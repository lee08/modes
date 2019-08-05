using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
	public float speed;
	public float lifeTime;
	public float radius = 5.0f;
	public float power = 10.0f;
	private GameObject bluePortal;
	public GameObject destroyEffect;
	public GameObject spawnEffect;
	//private GameObject gun;
	//public LayerMask whatIsEffected;

	private void Start(){
		Invoke ("DestroyProjectile", lifeTime);
		//gun = GameObject.FindGameObjectWithTag ("Hold");
	}

	private void Update () {
		transform.Translate (Vector2.up * speed*Time.deltaTime);
		if (Input.GetMouseButtonDown (1)) {
			DestroyProjectile();
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground")){
			DestroyProjectile();
		}
	}


	void DestroyProjectile(){
		if (destroyEffect != null) {
			Instantiate (destroyEffect, transform.position, Quaternion.identity);
		}
		Vector2 explosionPos = transform.position;
		Collider2D[] coll = Physics2D.OverlapCircleAll (explosionPos, radius);
		foreach (Collider2D hit in coll) {
			if (hit.CompareTag ("Player")) {
				Rigidbody2D rbb = hit.GetComponent<Rigidbody2D> ();
				Vector2 addd = new Vector2 ((explosionPos.x - hit.transform.position.x), (explosionPos.y - hit.transform.position.y));
				/*if (addd.x>10f) {
					addd.x = 10f;
				}
				if (addd.y > 10f) {
					addd.y = 10f;
				}*/
				rbb.AddForce (new Vector2(0f,addd.normalized.y*-1f*power));
				hit.GetComponent<basic> ().justforrocket += addd.normalized.x*-1f*power;
			}
		}
		//Debug.Log ("fgd");
		Destroy (gameObject);
	}
}
