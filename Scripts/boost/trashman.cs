using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashman : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("I'm the trashman");
		Destroy (other);
	}
	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("I'm the trashman");
		Destroy (other);
	}
}
