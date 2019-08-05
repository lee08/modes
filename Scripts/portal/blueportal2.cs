using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueportal2 : MonoBehaviour {
	public float speed;
	public float lifeTime;
	private GameObject bluePortal;
	public bool blue;
	public GameObject destroyEffect;
	public GameObject spawnEffect;
	private GameObject gun;

	private void Start(){
		Invoke ("DestroyProjectile", lifeTime);
		gun = GameObject.FindGameObjectWithTag ("Hold");
		if (blue) {
			bluePortal = GameObject.FindGameObjectWithTag ("BluePortal");
		} else {
			bluePortal = GameObject.FindGameObjectWithTag ("OrangePortal");
		}
	}

	private void Update () {
		transform.Translate (Vector2.up * speed*Time.deltaTime);
		if (Input.GetMouseButtonDown(0)&&blue||Input.GetMouseButtonDown(1)&&!blue){
			
			woo ();
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground")){
			
			woo();
		}
	}


	public void DestroyProjectile(){
		if (destroyEffect != null) {
			Instantiate (destroyEffect, transform.position, Quaternion.identity);
		}
		if (blue) {
			gun.GetComponent<portal> ().shotb = true;
		} else {
			gun.GetComponent<portal> ().shoto = true;
		}
		Destroy (gameObject);
	}
	public virtual void woo(){
		//Vector3 pos = transform.position;
		//Vector3 frd = transform.position+transform.forward;
		//RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x,pos.y), new Vector2(frd.x,frd.y));
		//Debug.Log("Point of contact: "+hit.point);
		if (blue) {
			gun.GetComponent<portal> ().shotb = true;
		} else {
			gun.GetComponent<portal> ().shoto = true;
		}
		bluePortal.transform.position = transform.position;
		bluePortal.GetComponent<orangeportal> ().i = 0;
		//bluePortal.GetComponent<orangeportal> ().normal = hit.normal;
		if (spawnEffect != null) {
			Instantiate (spawnEffect, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}

}
