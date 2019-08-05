using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {
	private basic playersd;
	private float sped;
	public float speed;
	// Use this for initialization
	void Start () {
		playersd = GameObject.FindGameObjectWithTag ("Player").GetComponent<basic>();
		sped = playersd.speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Fire 3")) {
			playersd.speed = speed;
			//Debug.Log ("weee");
		}
		else {
			playersd.speed = sped;
		}
	}
}
