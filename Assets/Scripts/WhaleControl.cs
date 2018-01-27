using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleControl : MonoBehaviour {

	public List<GameObject> groups;
	public List<GameObject> whales;
	public List<GameObject> couple1;
	public List<GameObject> couple2;
	public List<GameObject> couple3;
	float force = 100f;

	void Start () {
		Physics.IgnoreLayerCollision(8,8);
		whales = new List<GameObject>(GameObject.FindGameObjectsWithTag("Whale"));
		groups = new List<GameObject>(GameObject.FindGameObjectsWithTag("Sphere"));
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

	public void CheckPairing(){
		int correct = 0;
		for(int i=0; i<3; i++){
			if(groups[i].transform.childCount == 3){
				if(couple1.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple1.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple1.Contains(groups[i].transform.GetChild(2).gameObject)){
					Debug.Log("couple1 in "+groups[i].transform.name);
					groups[i].transform.GetChild(0).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(0).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(1).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(1).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(2).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(2).GetComponent<MoveControl>().particles.Stop();
					groups[i].GetComponent<SpriteRenderer>().enabled=false;
					correct++;
				}

				if(couple2.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple2.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple2.Contains(groups[i].transform.GetChild(2).gameObject)){
					Debug.Log("couple2 in "+groups[i].transform.name);
					groups[i].transform.GetChild(0).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(0).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(1).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(1).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(2).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(2).GetComponent<MoveControl>().particles.Stop();
					groups[i].GetComponent<SpriteRenderer>().enabled=false;

					correct++;
				}

				if(couple3.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple3.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple3.Contains(groups[i].transform.GetChild(2).gameObject)){
					Debug.Log("couple3 in "+groups[i].transform.name);
					groups[i].transform.GetChild(0).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(0).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(1).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(1).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(2).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(2).GetComponent<MoveControl>().particles.Stop();
					groups[i].GetComponent<SpriteRenderer>().enabled=false;

					correct++;
				}
			}
		}
		Debug.Log("Correct was: "+correct);
	}


}
