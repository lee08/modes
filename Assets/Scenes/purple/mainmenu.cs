using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {
	public string att;
	// Use this for initialization
	public void PlayGame(){
		SceneManager.LoadScene (att);
	}

}
