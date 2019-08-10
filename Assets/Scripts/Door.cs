using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public string LevelToLoad;
	//private GameMaster gm;
	//public Text Textt;
	public bool autonextscene = false;
	public Transform tr;
	public bool justgo;
	//public GameObject main;

	void Update(){
		if (autonextscene) {
			if (tr == null /*|| main == null*/) {
				if (justgo) {
					SceneManager.LoadScene (LevelToLoad);
				}
			}
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			
			if (Input.GetButtonDown("Interact")) 
			{
				if (tr == null) {
					SceneManager.LoadScene (LevelToLoad);
				} else {
					col.transform.position = tr.position;
					//main.transform.position = tr.position;
				}
			}
		}
		if (autonextscene) {
			if (tr == null /*|| main == null*/) {
				if (col.CompareTag ("Player")||justgo) {
					SceneManager.LoadScene (LevelToLoad);
				}
			} else {
				col.transform.position = tr.position;
				//main.transform.position = tr.position;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			
			if (Input.GetButtonDown ("Interact")) 
			{
				if (tr == null) {
					SceneManager.LoadScene (LevelToLoad);
				} else {
					col.transform.position = tr.position;
					//main.transform.position = tr.position;
				}
			}
		}
		if (autonextscene) {
			if (tr == null /*|| main == null*/) {
				if (col.CompareTag ("Player")||justgo) {
					SceneManager.LoadScene (LevelToLoad);
				}
			} else {
				col.transform.position = tr.position;
				//main.transform.position = tr.position;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		//Textt.text = ("");
		/*if (indicate != null) {
			indicate.enabled = false;
		}*/
	}


}
