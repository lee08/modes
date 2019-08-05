using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraSize : MonoBehaviour {
	
	public Camera cam;
	public camerafollow camfol;
	public float speed = 0.5f;
	public float size;
	public bool transition = false;
	public bool movey = false;
	public bool snappy = false;
	public bool turny = true;
	public GameObject posity;
	public float positymove;
	public GameObject ppp;
	public Vector3 oofset;
	private float yy;
	private float xx;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		camfol = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camerafollow>();
		ppp = GameObject.FindGameObjectWithTag ("Player");
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		yy = GameObject.FindGameObjectWithTag ("MainCamera").transform.position.y;
		xx = GameObject.FindGameObjectWithTag ("MainCamera").transform.position.x;
		if (col.CompareTag ("Player")) 
		{
			camfol.followy = movey;
			camfol.snapy = snappy;
			transition = true;
			camfol.enabled = turny;
			if (posity != null) {
				//ppp.GetComponent<basic> ().enabled = false;

				//yy = Mathf.Lerp(yy, posity.transform.position.y, positymove);
				//xx = Mathf.Lerp(xx, posity.transform.position.x, positymove);
				GameObject.FindGameObjectWithTag ("MainCamera").transform.position =  new Vector3 (xx, yy, GameObject.FindGameObjectWithTag ("MainCamera").transform.position.z);
				//ppp.GetComponent<basic> ().enabled = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			//if (oofset != new Vector2()) {
				camfol.offset = oofset;
			//}
			camfol.followy = movey;
			camfol.snapy = snappy;
			transition = true;
			camfol.enabled = turny;
			if (posity != null) {
				yy = Mathf.Lerp(yy, posity.transform.position.y, positymove);
				xx = Mathf.Lerp(xx, posity.transform.position.x, positymove);
				GameObject.FindGameObjectWithTag ("MainCamera").transform.position =  new Vector3 (xx, yy, GameObject.FindGameObjectWithTag ("MainCamera").transform.position.z);

			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.CompareTag ("Player")) 
		{
			transition = false;
		}
	}


	void Update(){
		if (transition) {
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, size, speed);
		}
	}


}
