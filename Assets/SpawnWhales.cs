using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWhales : MonoBehaviour {

	public GameObject valas;

	// Use this for initialization
	void Start () {
		System.Random rnd = new System.Random();
		
		for (int i = 0; i < 4; i++)
		{
			float coordX = rnd.Next(-14,15) * 1.0F;
			float coordY = rnd.Next(-4,4) * 1.0F;

			var uusiValas = Instantiate(valas, new Vector3(coordX, coordY, 0), Quaternion.identity);

			if (i%2 == 0) {
				uusiValas.GetComponent<MoveWhaleOnMenu>().Flip();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
