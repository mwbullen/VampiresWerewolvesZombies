﻿using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {
	public GameObject Human;
	public GameObject Zombie;

	public int humanCount;

	Quaternion q = Quaternion.Euler (0,0,0);
	// Use this for initialization
	void Start () {
		loadHumans ();
	}
	
	// Update is called once per frame
	void Update () {
	
			if (Input.GetMouseButton(0)) {
					clickObject();
				}
	}


	void clickObject() {
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit r_hit;

		if (Physics.Raycast (r, out r_hit, Mathf.Infinity)) {
			//Debug.Log (r_hit.collider.gameObject.tag);

			if (r_hit.collider.gameObject.tag == "Human") {
				createZombie(r_hit.collider.gameObject.transform.position);
				Destroy(r_hit.collider.gameObject);
			}
		}

	}
	//Create humans per HumanCount
	void loadHumans() {
	
		for (int i = 0; i<humanCount; i++) {

			float x = Random.Range(30, 70);
			float z = Random.Range(30, 70);

			//Quaternion q = Quaternion.Euler (0,0,0);

			Instantiate(Human, new Vector3(x, .5f, z), q);
		}
	}


	void createZombie(Vector3 position) {
		Instantiate (Zombie, position, q);
	}
}
