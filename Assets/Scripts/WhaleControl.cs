using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleControl : MonoBehaviour {

	public List<GameObject> whales;
	public List<GameObject> couple1;
	public List<GameObject> couple2;
	public List<GameObject> couple3;
	float force = 100f;


	void Start () {
		Physics.IgnoreLayerCollision(8,8);
		whales = new List<GameObject>(GameObject.FindGameObjectsWithTag("Whale"));
		List<GameObject> whalesTemp = new List<GameObject>(whales);

		couple1 = new List<GameObject>();
		couple1 = new List<GameObject>();
		couple1 = new List<GameObject>();

		for(int i=0; i<3; i++){
			int idx = Random.Range(0,whalesTemp.Count);
			couple1.Add(whalesTemp[idx]);
			whalesTemp.RemoveAt(idx);
		}
		for(int i=0; i<3; i++){
			int idx = Random.Range(0,whalesTemp.Count);
			couple2.Add(whalesTemp[idx]);
			whalesTemp.RemoveAt(idx);
		}
		for(int i=0; i<3; i++){
			int idx = Random.Range(0,whalesTemp.Count);
			couple3.Add(whalesTemp[idx]);
			whalesTemp.RemoveAt(idx);
		}

	}


}
