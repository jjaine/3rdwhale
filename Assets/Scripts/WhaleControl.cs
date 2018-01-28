using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleControl : MonoBehaviour {

	public List<GameObject> groups;
	public List<GameObject> hearts;
	public List<GameObject> whales;
	public List<GameObject> couple1;
	public List<GameObject> couple2;
	public List<GameObject> couple3;
	float force = 100f;
	public AudioSource theme, themelpf;
	float themeValue=0.5f, lpfValue=0;
	public List<AudioClip> fSounds;
	public List<AudioClip> gSounds;
	public List<AudioClip> amSounds;

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

		foreach(GameObject whale in whales){
			if(couple1.Contains(whale)){
				int idx = Random.Range(0, fSounds.Count);
				whale.GetComponent<AudioSource>().clip = fSounds[idx];
				fSounds.RemoveAt(idx);
			}
			else if(couple2.Contains(whale)){
				int idx = Random.Range(0, gSounds.Count);
				whale.GetComponent<AudioSource>().clip = gSounds[idx];
				gSounds.RemoveAt(idx);
			}
			else if(couple3.Contains(whale)){
				int idx = Random.Range(0, amSounds.Count);
				whale.GetComponent<AudioSource>().clip = amSounds[idx];
				amSounds.RemoveAt(idx);
			}
		}

	}

	public void CheckPairing(){
		int correct = 0;
		for(int i=0; i<3; i++){
			if(groups[i].transform.childCount == 3){
				if(couple1.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple1.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple1.Contains(groups[i].transform.GetChild(2).gameObject)){

					Transform child1 = groups[i].transform.GetChild(0);
					Transform child2 = groups[i].transform.GetChild(1);
					Transform child3 = groups[i].transform.GetChild(2);
					child1.GetComponent<Collider>().enabled = false;
					child1.GetComponent<MoveControl>().particles.Stop();
					child2.GetComponent<Collider>().enabled = false;
					child2.GetComponent<MoveControl>().particles.Stop();
					child3.GetComponent<Collider>().enabled = false;
					child3.GetComponent<MoveControl>().particles.Stop();
					
					groups[i].GetComponent<SpriteRenderer>().enabled=false;
					correct++;
					hearts[i].GetComponent<ParticleSystem>().Play();

					child2.position = new Vector3(child1.position.x, child1.position.y+0.7f, child2.position.z);
					child3.position = new Vector3(child1.position.x, child2.position.y+0.7f, child3.position.z);
					child2.GetComponent<Animator>().SetTrigger("rot");
					child3.GetComponent<Animator>().SetTrigger("ready");
				}

				if(couple2.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple2.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple2.Contains(groups[i].transform.GetChild(2).gameObject)){
					
					Transform child1 = groups[i].transform.GetChild(0);
					Transform child2 = groups[i].transform.GetChild(1);
					Transform child3 = groups[i].transform.GetChild(2);
					child1.GetComponent<Collider>().enabled = false;
					child1.GetComponent<MoveControl>().particles.Stop();
					child2.GetComponent<Collider>().enabled = false;
					child2.GetComponent<MoveControl>().particles.Stop();
					child3.GetComponent<Collider>().enabled = false;
					child3.GetComponent<MoveControl>().particles.Stop();
					
					groups[i].GetComponent<SpriteRenderer>().enabled=false;
					correct++;
					hearts[i].GetComponent<ParticleSystem>().Play();

					child2.position = new Vector3(child1.position.x, child1.position.y+0.7f, child2.position.z);
					child3.position = new Vector3(child1.position.x, child2.position.y+0.7f, child3.position.z);
					child2.GetComponent<Animator>().SetTrigger("rot");
					child3.GetComponent<Animator>().SetTrigger("ready");
				}

				if(couple3.Contains(groups[i].transform.GetChild(0).gameObject) && 
					couple3.Contains(groups[i].transform.GetChild(1).gameObject) &&
					couple3.Contains(groups[i].transform.GetChild(2).gameObject)){
					
					Transform child1 = groups[i].transform.GetChild(0);
					Transform child2 = groups[i].transform.GetChild(1);
					Transform child3 = groups[i].transform.GetChild(2);
					child1.GetComponent<Collider>().enabled = false;
					child1.GetComponent<MoveControl>().particles.Stop();
					child2.GetComponent<Collider>().enabled = false;
					child2.GetComponent<MoveControl>().particles.Stop();
					child3.GetComponent<Collider>().enabled = false;
					child3.GetComponent<MoveControl>().particles.Stop();
					
					groups[i].GetComponent<SpriteRenderer>().enabled=false;
					correct++;
					hearts[i].GetComponent<ParticleSystem>().Play();

					child2.position = new Vector3(child1.position.x, child1.position.y+0.7f, child2.position.z);
					child3.position = new Vector3(child1.position.x, child2.position.y+0.7f, child3.position.z);
					child2.GetComponent<Animator>().SetTrigger("rot");
					child3.GetComponent<Animator>().SetTrigger("ready");
				}
			}
		}
		Debug.Log("Correct was: "+correct);
		if(correct == 3){
			foreach(GameObject whale in whales){
				whale.GetComponent<AudioSource>().Stop();
				whale.GetComponent<MoveControl>().particles.Stop();
			}
		}
	}

	public void PlayGroup(int i){
		//theme.volume = 0;
		//themelpf.volume = 1;
		SetValues(0, 0.1f);

		foreach(GameObject whale in whales){
			whale.GetComponent<AudioSource>().Stop();
			whale.GetComponent<MoveControl>().particles.Stop();
		}

		for(int j=0; j<groups[i].transform.childCount; j++){
			groups[i].transform.GetChild(j).GetComponent<AudioSource>().Play();
			groups[i].transform.GetChild(j).GetComponent<MoveControl>().particles.Play();
		}
	}

	void Update(){
		theme.volume += (themeValue-theme.volume)/100;
		themelpf.volume += (lpfValue-themelpf.volume)/100;
	}

	public void SetValues(float themeV, float lpfV){
		themeValue = themeV;
		lpfValue = lpfV;
	}


}
