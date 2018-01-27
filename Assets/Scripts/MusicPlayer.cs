using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	public AudioClip intro;
	public AudioClip loop;
	public AudioSource player;

	void Start(){
		player.clip = intro;
		player.Play();
	}

	void Update(){
		if(!player.isPlaying){
			player.clip = loop;
			player.loop = true;
			player.Play();
		}
	}
}
