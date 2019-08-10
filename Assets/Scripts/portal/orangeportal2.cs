using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeportal2 : MonoBehaviour {
	private GameObject orangePortal;
	public bool blue;
	public bool passing = true;
	public Vector2 normal;

	void Start(){
		if (blue) {
			orangePortal = GameObject.FindGameObjectWithTag ("OrangePortal");
		} else {
			orangePortal = GameObject.FindGameObjectWithTag ("BluePortal");
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((!other.CompareTag ("Ground")) && passing) {
			orangePortal.GetComponent<orangeportal> ().passing = false;
			other.transform.position = orangePortal.transform.position;
			Vector2 vel = other.GetComponent<Rigidbody2D> ().velocity;
			float rad = Mathf.Acos(Vector2.Dot(normal.normalized,(new Vector2(1f,0f))));
			other.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((vel.x * Mathf.Cos (rad) - vel.y * Mathf.Sin (rad)) * -1f, (vel.x * Mathf.Sin (rad) + vel.y * Mathf.Cos (rad)));
		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag ("Ground")) {
			passing = true;
		}

	}

}
