using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeportal : MonoBehaviour {
	private GameObject orangePortal;
	public bool blue;
	public bool passing = true;
	public Vector2 normal;
	private bool exceptplayer;
	private Color co;
	//private bool colorchanged = false;
	private Color redco;
	public int i;
	//public AudioClip aab;
	public AudioSource bab;

	void Start(){
		if (blue) {
			orangePortal = GameObject.FindGameObjectWithTag ("OrangePortal");
		} else {
			orangePortal = GameObject.FindGameObjectWithTag ("BluePortal");
		}
		co = this.GetComponent<SpriteRenderer> ().color;
		redco = co + new Color(0.2f, 0.2f, 0.2f, 0f);
		i = 0;
		//bab.clip = aab;
	}
	void Update(){
		
		if (exceptplayer||orangePortal.GetComponent<orangeportal> ().exceptplayer) {
			float xx = Mathf.Lerp(redco.r, this.GetComponent<SpriteRenderer> ().color.r, 0.01f);
			this.GetComponent<SpriteRenderer> ().color=new Color (xx, redco.g,redco.b, redco.a);
		}
		else {
			float xx = Mathf.Lerp(co.r, this.GetComponent<SpriteRenderer> ().color.r, 0.01f);
			this.GetComponent<SpriteRenderer> ().color=new Color (xx, co.g, co.b, co.a);
		}

	}
	void FixedUpdate(){
		Collider2D[] aaa = Physics2D.OverlapCircleAll(this.transform.position,0.5f,~0);
		Debug.Log (aaa);
		foreach (Collider2D c in aaa){

			if (c.CompareTag ("noplayer")) {
				i++;
			} 
		}
		if (i == 0) {
			exceptplayer = false;
		} else {
			exceptplayer = true;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (((other.CompareTag ("Player")&&!orangePortal.GetComponent<orangeportal> ().exceptplayer&&!exceptplayer)||other.CompareTag ("Portalball")) && passing) {
			orangePortal.GetComponent<orangeportal> ().passing = false;
			other.transform.position = orangePortal.transform.position;
			bab.Play();
		}
		/*if (other.CompareTag ("noplayer")) {
			exceptplayer = true;
		} else {
			exceptplayer = false;
		}*/
	}
	void OnTriggerStay2D(Collider2D col){
		
		/*if (col.CompareTag ("noplayer")) {
			exceptplayer = true;
		} else {
			exceptplayer = false;
		}*/
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag ("Ground")) {
			passing = true;
		}

	}

}
