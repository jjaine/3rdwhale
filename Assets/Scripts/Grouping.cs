using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grouping : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		if(c.tag == "Whale"){
			c.transform.parent = transform;
		}
	}

	/*void OnTriggerExit(Collider c){
		if(c.tag == "Whale"){
			c.transform.parent = transform.parent;
		}
	}*/
}
