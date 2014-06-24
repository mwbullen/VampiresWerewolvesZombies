using UnityEngine;
using System.Collections;

public class zombieAi : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void showZombie() {
		this.renderer.enabled = true;

	}

	void hideZombie() {
		this.renderer.enabled = false;
	}
}
