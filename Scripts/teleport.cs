using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public float offset = -90f;
	private Transform player;
	private basic ba;
	public int limit;
	public int clicks = 0;
	public bool reset;
	public float rechargetime = 1f;
	private float charging = 1f;
	public float radius = 100f;
	private Vector3 mousepos;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//ba = GameObject.FindGameObjectWithTag ("Player").GetComponent<basic> ();
	}
	
	// Update is called once per frame
	void Update () {
		mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 difference = mousepos - transform.position;
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f,0f,rotZ+offset);
		if (Input.GetMouseButtonDown (0)) {
			if (clicks <= limit || limit == -27) {
				Nyoom (player);
				clicks++;
			}
		}
		if (clicks > 0) {
			charging -= Time.deltaTime;
			if(charging < 0){
				charging = rechargetime;
				clicks--;
			}
		}
		/*if (ba.isGrounded) {
			clicks = 0;
		}*/
	}

	public void Nyoom(Transform tr){
		mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 centerPosition = tr.position;
		float distance = Vector3.Distance (mousepos, centerPosition);
		Vector3 new_pos;
		if (distance > radius) {
			Vector3 fromOriginToObject = mousepos - centerPosition;
			fromOriginToObject *= radius / distance;
			new_pos = centerPosition + fromOriginToObject;
			Debug.Log (new_pos);

		} else {
			new_pos = mousepos;
			Debug.Log ("ssds"+new_pos);
		}
		new_pos.z = tr.position.z;

		tr.position = new_pos;
		if (reset) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
		}
	}
}
