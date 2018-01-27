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
	float themeValue=1, lpfValue=0;
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
					Debug.Log("couple1 in "+groups[i].transform.name);
					groups[i].transform.GetChild(0).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(0).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(1).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(1).GetComponent<MoveControl>().particles.Stop();
					groups[i].transform.GetChild(2).GetComponent<Collider>().enabled = false;
					groups[i].transform.GetChild(2).GetComponent<MoveControl>().particles.Stop();
					groups[i].GetComponent<SpriteRenderer>().enabled=false;
					correct++;
					hearts[i].GetComponent<ParticleSystem>().Play();
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
					hearts[i].GetComponent<ParticleSystem>().Play();
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
					hearts[i].GetComponent<ParticleSystem>().Play();
				}
			}
		}
		Debug.Log("Correct was: "+correct);
	}

	public void PlayGroup(int i){
		//theme.volume = 0;
		//themelpf.volume = 1;
		SetValues(0, 1);

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

	public void SetValues(int themeV, int lpfV){
		themeValue = themeV;
		lpfValue = lpfV;
	}


}
