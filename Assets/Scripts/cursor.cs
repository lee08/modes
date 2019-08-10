using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour {


	private SpriteRenderer rend;
	public Sprite heldCursor;
	public Sprite normalCursor;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void OnGUI () {
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = cursorPos;
		if (Input.GetMouseButtonDown (0)) {
			rend.sprite = heldCursor;
		} else if (Input.GetMouseButtonUp (0)) {
			rend.sprite = normalCursor;
		}
	}
}
