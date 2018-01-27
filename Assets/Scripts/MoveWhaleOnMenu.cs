using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhaleOnMenu : MonoBehaviour {

	private Vector3 direction = Vector3.left;
	private int valasCount = 0;
	
	public GameObject valas;
	
	// Use this for initialization
	void Start () {
		/* System.Random rnd = new System.Random();
		
		for (int i = 0; i < 6; ++i) {
			float coordX = rnd.Next(-14,15) * 1.0F;
			float coordY = rnd.Next(-8,9) * 1.0F;
			
			Instantiate(valas, new Vector3(coordX, coordY, 0), Quaternion.identity);
		} */
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction * Time.deltaTime);
		// transform.Rotate(0,2*Time.deltaTime, 0);
		
		if (Math.Abs(transform.position.x) > 14) {
			transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
			direction = direction * -1;
			// transform.Translate(direction * Time.deltaTime);
			// transform.Rotate(new Vector3(0,180,0));
		}
	}
	
	/* void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("törmäys!\n");
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		direction = direction * -1;
	} */
}
