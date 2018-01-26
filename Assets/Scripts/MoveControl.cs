using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	Rigidbody rb;
	bool locked;
	public ParticleSystem particles;
	float force = 100f;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
		particles = transform.GetChild(1).GetComponent<ParticleSystem>();
	}

	void OnMouseDown(){
		List<GameObject> whales = Camera.main.GetComponent<WhaleControl>().whales;

		for(int i=0; i<whales.Count; i++){
			whales[i].GetComponent<MoveControl>().particles.Stop();
		}

		particles.Play();

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit)){

			if(hit.collider == transform.GetComponent<Collider>()){
				if(!locked){
					float xPoint = Camera.main.transform.InverseTransformPoint(transform.position).x;

					if(hit.point.x-xPoint > 0.4f){
						rb.AddForce(new Vector3(-0.2f, 0.5f, 0)*force);
					}
					else if(hit.point.x-xPoint < -0.4f){
						rb.AddForce(new Vector3(0.2f, 0.5f, 0)*force);
					}
					else{
						rb.AddForce(new Vector3(0, 0.5f, 0)*force);
					}
				}
			}
			else if(hit.collider == transform.GetChild(0).GetComponent<Collider>()){
				if(!locked){
					rb.useGravity = false;
					rb.velocity = Vector3.zero;
				}
				else{
					rb.useGravity = true;
				}

				locked = !locked;
				if(transform.GetChild(0).GetComponent<SpriteRenderer>().color == Color.red)
					transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
				else
					transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
			}
		}
	}
}
