using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueportal : projectile {
	
	private GameObject bluePortal;
	public bool blue;
	void Start(){
		if (blue) {
			bluePortal = GameObject.FindGameObjectWithTag ("BluePortal");
		} else {
			bluePortal = GameObject.FindGameObjectWithTag ("OrangePortal");
		}
	}


	public override void woo()
	{
		//normalfind ();
		//ContactPoint2D hit = new ContactPoint2D();

		//Instantiate (splat, transform.position, splat.transform.rotation);

		Vector3 pos = transform.position;
		Vector3 frd = transform.position+transform.forward;
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x,pos.y), new Vector2(frd.x,frd.y));
		Debug.Log("Point of contact: "+hit.point);

		bluePortal.GetComponent<orangeportal> ().normal = hit.normal;
		Debug.Log (hit.normal);
		bluePortal.transform.position = transform.position;
		//bluePortal.GetComponent<orangeportal> ().normal = hit.normal;
		Destroy (gameObject);
	}
	//public override void loo(Collision2D o){
		
	//}


}
