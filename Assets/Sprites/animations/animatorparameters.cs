using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorparameters : MonoBehaviour {

	Animator animator;
	public Animator specificanimator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		//float h = Input.GetAxis("Horizontal");
		//float v = Input.GetAxis("Vertical");
		bool click = Input.GetMouseButton(0);
		bool click0 = Input.GetMouseButton(1);
		//animator.SetFloat("Forward",v);
		//animator.SetFloat("Strafe",h);
		animator.SetBool("click", click);
		animator.SetBool("click0", click0);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			animator.SetBool("goal", true);
			Invoke ("yeah", 0.2f);
		}

	}
	void yeah(){
		if (specificanimator != null) {
			specificanimator.SetBool("fade", true);
		}
	}
}
