using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusflame : MonoBehaviour {
	public Animator ani;
	public basic playe;

	public void Start(){
		playe = GameObject.FindGameObjectWithTag ("Player").GetComponent<basic>();
	}
	public void Update(){
		if (Mathf.Floor(playe.bonus) > 2f) {
			ani.SetBool ("two", true);
		} else if (Mathf.Floor(playe.bonus) > 1f) {
			ani.SetBool ("one", true);
		} else if (playe.bonus > 0f) {
			ani.SetBool ("zero", true);
		} else {
			ani.SetBool ("two", false);
			ani.SetBool ("one", false);
			ani.SetBool ("zero", false);
		}
	}
}
