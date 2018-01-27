using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleControl : MonoBehaviour {

	public List<GameObject> whales;
	float force = 100f;

	void Start () {
		Physics.gravity = new Vector3(0, -0.5F, 0);
		Physics.IgnoreLayerCollision(8,8);
		whales = new List<GameObject>(GameObject.FindGameObjectsWithTag("Whale"));
	}
}
