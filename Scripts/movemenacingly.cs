using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemenacingly : MonoBehaviour {
	public float speed;
	public float lifeTime;

	public GameObject destroyEffect;
	public Vector2 sss;
	public int damage;
	public bool bekind;
	// Use this for initialization

	private void Start(){
		if (lifeTime != -27f) {
			Invoke ("DestroyProjectile", lifeTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (sss * speed*Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			woo(other);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			woo(other);
		}
	}

	void DestroyProjectile(){
		if (destroyEffect != null) {
			Instantiate (destroyEffect, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}
	public virtual void woo(Collider2D c){
		if (bekind && c.GetComponent<basic> ().hrt) {
			Debug.Log ("I'll let you pass... this time.");
		} else {
			c.GetComponent<basic> ().health -= damage;
			if (damage > 0) {
				c.GetComponent<basic> ().hrt = true;
			}
		}
	}
}
