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
		
		if (Math.Abs(transform.position.x) > 10) {
			transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
			direction = direction * -1;
		}
	}
	
	/* void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("törmäys!\n");
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		direction = direction * -1;
	} */
}
