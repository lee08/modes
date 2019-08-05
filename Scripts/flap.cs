using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flap : MonoBehaviour {
	public int wextraJumpsvalue;
	public bool jetpackon;
	public int wlimit;
	private Transform player;
	private basic ba;
	//private teleport tp;
	public bool topdownon;
	public float maxboost = 1f;

	void Start(){

	}
	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		ba = player.GetComponent<basic> ();
		//tp = player.GetComponent<teleport> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			ba = other.GetComponent<basic> ();
			if (ba!=null){
				ba.extraJumpValue = wextraJumpsvalue;
				ba.jetpack = jetpackon;
				ba.topdown = topdownon;
				ba.boostmax = maxboost;
			}
			/*if (tp!=null){
				tp.limit = wlimit;
				tp.clicks = 0;
			}*/
		}
	}

}
