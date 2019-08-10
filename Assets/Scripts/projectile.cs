using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
	public float speed;
	public float lifeTime;

	public GameObject destroyEffect;

	private void Start(){
		Invoke ("DestroyProjectile", lifeTime);
	}

	private void Update () {
		transform.Translate (Vector2.up * speed*Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground")){
			woo();
		}
	}
	void OnCollisionEnter2D(Collision2D oth)
	{
		loo (oth);
	}

	void DestroyProjectile(){
		if (destroyEffect != null) {
			Instantiate (destroyEffect, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}
	public virtual void woo(){
		if (destroyEffect != null) {
			Instantiate (destroyEffect, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}

	public virtual void loo(Collision2D o){
		Debug.Log (o.contacts [0].normal);
	}

}
