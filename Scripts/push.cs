using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour {

	public float power;
	public float duration;
	//public Vector2 direction;
	private float store;
	private float timeLeft = 0;
	// Use this for initialization
	void Start () {
		store = GameObject.FindGameObjectWithTag ("Player").GetComponent<basic> ().speed;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		/*if (!other.CompareTag ("Ground")){
			if (other.GetComponent<Rigidbody2D> () != null) {
				other.GetComponent<Rigidbody2D> ().AddForce (direction * power);
			}
		}*/
		if (other.CompareTag ("Player")) {
			if (timeLeft < 0) {
				store = GameObject.FindGameObjectWithTag ("Player").GetComponent<basic> ().speed;
			}
			timeLeft = duration;
		}

	}


	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft > 0) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<basic> ().speed = power;
		} else {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<basic> ().speed = store;
		}
	}
}
