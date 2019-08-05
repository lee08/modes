using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public static float timerr;
	public static float timerentered;
	public bool stoptimer;
	Text text;
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
		timerr = 0;
		stoptimer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!stoptimer) {
			timerr += Time.deltaTime;
		}

		int csec = (int) (timerr*100 % 60);
		int sec = (int) (timerr % 60);
		int min = (int) (timerr / 60) % 60;
		int hrs = (int) (timerr / 3600) % 24;
		string timerrr = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", hrs, min, sec, csec);
		text.text = "" + timerrr;
	}
}
