﻿using UnityEngine;
using System.Collections;

public class humanAi : MonoBehaviour {
	Vector3 direction;

	public NavMeshAgent navAgent;
	GameObject currentTarget;

	public float runSpeed;
	float baseSpeed;

	// Use this for initialization
	void Start () {

		//set Random rotation for visual interest
		transform.rotation = getRandomRotation ();

		//load NavAgent
		navAgent = (NavMeshAgent)GetComponent("NavMeshAgent");

		//Pick a random target from the designated objects
		currentTarget = getRandomNavTarget ();

		//store base navagent speed in variable
		baseSpeed = navAgent.speed;

		//Go to new target
		navAgent.SetDestination(currentTarget.transform.position);
	}


	Quaternion getRandomRotation() {
		int y = Random.Range (0, 360);		
		Quaternion q = Quaternion.Euler (0, y, 0);		
		return q;
		
	}

	//return randomly selected nav target
	GameObject getRandomNavTarget() {
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Finish");

		int x = Random.Range (0, targets.Length);

		return targets [x];
	}


	// Update is called once per frame
	void Update () {

		//If close to nav destination, pick new random destination to keep moving
		if (navAgent.remainingDistance < 5) {
						currentTarget = getRandomNavTarget ();
			navAgent.speed = baseSpeed;
						navAgent.SetDestination (currentTarget.transform.position);
				}

		}

	//Destroy human object
	void die() {
		Destroy (gameObject);
		}

	//Sprint to "safe" location (0,0,0 is test)
	void Afraid() {
		navAgent.Stop ();
		navAgent.speed = runSpeed;
		navAgent.SetDestination (new Vector3 (0, 0, 0));
	}

}
