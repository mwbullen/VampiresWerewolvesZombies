using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {
	public GameObject Human;
	public int humanCount;


	// Use this for initialization
	void Start () {
		loadHumans ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	//Create humans per HumanCount
	void loadHumans() {
	
		for (int i = 0; i<humanCount; i++) {

			float x = Random.Range(30, 70);
			float z = Random.Range(30, 70);

			Quaternion q = Quaternion.Euler (0,0,0);

			Instantiate(Human, new Vector3(x, .5f, z), q);
		}
	}

}
