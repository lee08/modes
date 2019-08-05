using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour {
	public GameObject child;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			if (other.GetComponent<basic>().bashing||Mathf.Abs(other.GetComponent<Rigidbody2D> ().velocity.y)>40f) {
				Destroy (child);
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player")){
			if (other.GetComponent<basic>().bashing||Mathf.Abs(other.GetComponent<Rigidbody2D> ().velocity.y)>40f) {
				Destroy (child);
			}
		}
	}
}
