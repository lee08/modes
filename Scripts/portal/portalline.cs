using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalline : MonoBehaviour {
	public float speed;
	public float lifeTime;

	public GameObject destroyEffect;

	private RaycastHit2D hit;

	private void Start(){
		Invoke ("DestroyProjectile", lifeTime);
	}

	private void Update () {
		transform.Translate (Vector2.up * speed*Time.deltaTime);
		Vector3 pos = transform.position;
		Vector3 frd = transform.position+transform.forward;
		hit = Physics2D.Raycast(new Vector2(pos.x,pos.y), new Vector2(frd.x,frd.y));
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground")){
			Debug.Log("Point of contact: "+hit.point);
			Debug.Log(hit.normal);
			woo ();
		}
	}
	void OnCollisionEnter2D(Collision2D oth)
	{
		//loo (oth);
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
