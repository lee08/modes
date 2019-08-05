using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killportal : MonoBehaviour {
	//public GameObject destroyEffect;
	private GameObject hold;
	// Use this for initialization

	private void Start(){
		hold = GameObject.FindGameObjectWithTag ("Hold");
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Portalball")){
			/*if (destroyEffect != null) {
				Instantiate (destroyEffect, transform.position, Quaternion.identity);
			}
			if (other.GetComponent<blueportal2> ().blue) {
				hold.GetComponent<portal> ().shotb = true;
			} else {
				hold.GetComponent<portal> ().shoto = true;
			}
			Destroy (other.gameObject);*/
			other.GetComponent<blueportal2> ().DestroyProjectile ();
		}
	}

}
