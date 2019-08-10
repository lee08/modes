using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour {
	public string aaaa;
	// Use this for initialization
	void Awake () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag (aaaa);
		if(objs.Length>1){
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}

}
