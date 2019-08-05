using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class applychange : MonoBehaviour {
	[Serializable]
	public class Myevent : UnityEvent{}

	[SerializeField]
	private Myevent myevent = new Myevent();
	public Myevent onmyevent { get { return myevent; } set { myevent = value; } }
	public bool justdoit;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")|| justdoit) {
			triggered ();
			//Debug.Log ("asd");
		}
	}



	public void triggered(){
		myevent.Invoke();
	}
}
