using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoenix : MonoBehaviour {
	private Animator anim;
	public int helth = 9;
	public bool hurt;
	public GameObject spawnerr;
	public bool hmm;
	public bool okgotit;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Debug.Log (other.GetComponent<Rigidbody2D> ().velocity.y);
			if (!hurt) {	
				if (other.GetComponent<Rigidbody2D> ().velocity.y > 100f || other.GetComponent<Rigidbody2D> ().velocity.x > 140) {
					helth -= 3;
					hmm = true;
					hurt = true;
				} else if (other.GetComponent<Rigidbody2D> ().velocity.y > 70f || other.GetComponent<Rigidbody2D> ().velocity.x > 90) {
					helth -= 2;
					hmm = true;
					hurt = true;
				} else if (other.GetComponent<Rigidbody2D> ().velocity.y > 40f || other.GetComponent<Rigidbody2D> ().velocity.x > 40) {
					helth -= 1;
					hmm = true;
					hurt = true;
				}
				
			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			if (!hurt) {	
				if (other.GetComponent<Rigidbody2D> ().velocity.y > 100f || other.GetComponent<Rigidbody2D> ().velocity.x > 140) {
					helth -= 3;
					hmm = true;
					hurt = true;
				} else if (other.GetComponent<Rigidbody2D> ().velocity.y > 70f || other.GetComponent<Rigidbody2D> ().velocity.x > 90) {
					helth -= 2;
					hmm = true;
					hurt = true;
				} else if (other.GetComponent<Rigidbody2D> ().velocity.y > 40f || other.GetComponent<Rigidbody2D> ().velocity.x > 40) {
					helth -= 1;
					hmm = true;
					hurt = true;
				}

			}
		}
	}

	void Update(){
		//anim.SetBool ("hurt",hurt);
		if (hmm) {
			anim.SetBool ("hurt", true);
		}
		if (!hurt) {
			anim.SetBool ("hurt", false);
		}
		if (okgotit) {
			anim.SetBool ("end", false);
		}
		if (helth <= 12) {
			
			spawnerr.GetComponent<redspawner> ().level = 2;
			anim.SetBool ("next", true);
		}
		if (helth <= 6) {
			spawnerr.GetComponent<redspawner> ().level = 3;
			anim.SetBool ("nextt", true);
		}
		if (helth <= 0) {
			spawnerr.GetComponent<redspawner> ().level = 4;
			anim.SetBool ("end", !okgotit);

		}
	}

}
