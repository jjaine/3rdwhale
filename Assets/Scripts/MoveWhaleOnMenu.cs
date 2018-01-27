using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhaleOnMenu : MonoBehaviour {

	private Vector3 direction = Vector3.left;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction * Time.deltaTime);
		// transform.Rotate(0,2*Time.deltaTime, 0);
		
		if (Math.Abs(transform.position.x) > 14) {
			Flip();
			// transform.Translate(direction * Time.deltaTime);
			// transform.Rotate(new Vector3(0,180,0));
		}
	}

	public void Flip() {
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		direction = direction * -1;
	}
}
