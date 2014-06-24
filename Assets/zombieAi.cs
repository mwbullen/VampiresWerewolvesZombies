using UnityEngine;
using System.Collections;

public class zombieAi : MonoBehaviour {
	public float attackInterval;
	float timeSinceAttack;
	public float attackSize;

	public float lifeSpan;

	float timeAlive;

	public NavMeshAgent navAgent;
	GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
		//load NavAgent
		navAgent = (NavMeshAgent)GetComponent("NavMeshAgent");
		
		//Pick a random target from the designated objects
		currentTarget = getRandomNavTarget ();
		
		//Go to new target
		navAgent.SetDestination(currentTarget.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;

		if (timeAlive >= lifeSpan) {
			Destroy(this.gameObject);
				}

		timeSinceAttack += Time.deltaTime;
		
		if (timeSinceAttack > attackInterval) {
			
			attack();
			timeSinceAttack = 0;
			
		}

		
		//If close to nav destination, pick new random destination to keep moving
		if (navAgent.remainingDistance < 5) {
			currentTarget = getRandomNavTarget ();
			navAgent.SetDestination (currentTarget.transform.position);
		}
		
	}



	
	//return randomly selected nav target
	GameObject getRandomNavTarget() {
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Finish");
		
		int x = Random.Range (0, targets.Length);
		
		return targets [x];
	}


	void showZombie() {
		this.renderer.enabled = true;

	}

	void hideZombie() {
		this.renderer.enabled = false;
	}

	void attack() {
						
		RaycastHit r;

		//= Physics.SphereCastAll(new Ray (transform.position, transform.forward), attack_size, attack_size);
		//Debug.Log ("Attack" + "," + r_hits.Length);
		
		if (Physics.SphereCast (new Ray (transform.position, transform.forward), attackSize, out r, 3)) {		

			//	Debug.Log (r.collider.gameObject.tag);
				if (r.collider.gameObject.tag == "Human") {

				//		Debug.Log ("Hit");

				Camera.main.SendMessage("createZombie", r.collider.transform.position);

				//Instantiate (gameObject, r.collider.transform.position, r.collider.transform.rotation);
				Destroy (r.collider.gameObject);
				}
		}
	}
}
