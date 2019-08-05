using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour {
	public float effecttime = 0.5f;
	private float effectt = 0f;
	public float rechargetime = 1f;
	private float charging = 1f;
	public int limit = 2;
	public int clicks = 0;
	public float amount;
	public float amounty;
	private Transform player;

	private float grav;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		grav = player.GetComponent<Rigidbody2D> ().gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire 2")&&(Input.GetAxisRaw ("Horizontal")!=0f||Input.GetAxisRaw ("Vertical")!=0f)) {
			if (clicks <= limit || limit == -27) {
				grav = player.GetComponent<Rigidbody2D> ().gravityScale;
				Nyoom (player);

			}
		}

		if (clicks > 0) {
			charging -= Time.deltaTime;
			if(charging < 0){
				charging = rechargetime;
				clicks--;
			}
		}
		if (effectt > 0f) {
			effectt -= Time.deltaTime;
		} else {
			player.GetComponent<basic> ().enabled = true;
			player.GetComponent<Rigidbody2D> ().gravityScale = grav;
		}
	}
	public void Nyoom(Transform tr){
		//Vector2 velo = tr.GetComponent<Rigidbody2D> ().velocity;
		Vector2 vel = new Vector2();
	//	Debug.Log ("s"+vel);
		//Vector2 pus = new Vector2();
		if (Input.GetAxisRaw ("Horizontal")!=0f) {
			vel += new Vector2 (Input.GetAxisRaw ("Horizontal") * amount,0f);
			//pus = new Vector2 (Input.GetAxisRaw ("Horizontal") * amount, 0f);

		}
		if (Input.GetAxisRaw ("Vertical")!=0f) {
			vel += new Vector2 (0f, Input.GetAxisRaw ("Vertical") * amounty);
			//pus = new Vector2 (0f,Input.GetAxisRaw ("Vertical") * amount);
		}
		tr.GetComponent<basic> ().enabled = false;
		tr.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		effectt = effecttime;
		//tr.GetComponent<Rigidbody2D> ().AddForce (pus);
		tr.GetComponent<Rigidbody2D> ().velocity = vel;
	//	Debug.Log ("f"+tr.GetComponent<Rigidbody2D> ().velocity);
		clicks++;
	}
}
