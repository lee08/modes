using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject what;

	private float timeBtewSpawn;
	public float startTimeBtewSpawn;

	// Update is called once per frame
	private void Update () {
		if (timeBtewSpawn <= 0f) {
			Instantiate (what, transform.position, Quaternion.identity);
			timeBtewSpawn = startTimeBtewSpawn;
		} else {
			timeBtewSpawn -= Time.deltaTime;
		}
	}
}
