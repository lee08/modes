using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redspawner : MonoBehaviour {

	public int level = 1;
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("woaghh");
		if (col.CompareTag ("spawn")) 
		{
			Debug.Log ("woagh");
			if (level == 1) {
				Instantiate (level1, col.transform.position, Quaternion.identity);
			} else if (level == 2) {
				Instantiate (level2, col.transform.position, Quaternion.identity);
			} else if (level == 3) {
				Instantiate (level3, col.transform.position, Quaternion.identity);
			} else if (level == 4) {
				Instantiate (level4, col.transform.position, Quaternion.identity);
			}
		}
	}

}
