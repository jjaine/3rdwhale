using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	Rigidbody rb;
	bool locked;
	public ParticleSystem particles;
	float force = 100f;

	float x,y;
	float speed = 30.0f;
	float maxSpeed = 100.0f;

	void Start () {
		rb = GetComponent<Rigidbody>();
		particles = transform.GetChild(1).GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;
    	y = Input.mousePosition.y;
    	if(!Input.GetMouseButton(0)){
    		rb.velocity = Vector3.zero;
    	}
	}

	void OnMouseDown(){
		List<GameObject> whales = Camera.main.GetComponent<WhaleControl>().whales;

		for(int i=0; i<whales.Count; i++){
			whales[i].GetComponent<MoveControl>().particles.Stop();
			whales[i].GetComponent<AudioSource>().Stop();
		}

		particles.Play();
		GetComponent<AudioSource>().Play();
		
		Camera.main.GetComponent<WhaleControl>().SetValues(1, 0);
	}

	void OnMouseDrag(){
		if(!locked){
			Vector3 v = (Camera.main.ScreenToWorldPoint(new Vector3(x,y,9.0f))-transform.position)*speed;
			if(v.magnitude > maxSpeed) 
				v*=maxSpeed/v.magnitude;
			rb.velocity = v;
		}
	}
}
