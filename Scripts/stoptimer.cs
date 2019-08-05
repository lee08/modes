using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoptimer : MonoBehaviour {
	private timer timee;
	public bool opposite;
	// Use this for initialization
	void Start () {
		timee = GameObject.FindGameObjectWithTag ("realtimer").GetComponent<timer>();
	}
	
	// Update is called once per frame
	void Update () {
		timee.stoptimer = true;
		if (opposite) {
			timee.stoptimer = false;
		}
	}
}
