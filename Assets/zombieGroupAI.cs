using UnityEngine;
using System.Collections;

public class zombieGroupAI : MonoBehaviour {

	NavMeshAgent navAgent;
	GameObject currentTarget;

	public GameObject zombie;

	public GameObject[] zombies = new GameObject[9];
	int currentZombies =0;

	public float attackInterval;
	float timeSinceAttack;

	// Use this for initialization
	void Start () {

		/*for (int i = 0; i < zombies.Length; i++) {
			zombies[i] = Instantiate(zombie, zombies[i].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		}
*/
		navAgent = (NavMeshAgent)GetComponent("NavMeshAgent");
		
		//Pick a random target from the designated objects
		currentTarget = getRandomNavTarget ();

		//zombies [0].SendMessage ("showZombie");
		//currentZombies += 1;

		//Go to new target
		navAgent.SetDestination(currentTarget.transform.position);

	}

	void addZombie() {
				//zombies [currentZombies].SendMessage ("showZombie");

			//if (currentZombies == 10) {
					//startNewGroup ();
			//} else {

					float x = Random.Range (-5, 5);
					float z = Random.Range (-5, 5);

					GameObject newZombie = (GameObject)Instantiate (zombie); 
					newZombie.transform.parent = this.transform;

					newZombie.transform.localPosition = new Vector3 (x, .5f, z);
					//Debug.Log (newZombie);

					currentZombies += 1;
			//}
	}

	void startNewGroup() {
		Instantiate (this);

	}
	void removeZombie() {
		//zombies [currentZombies - 1].SendMessage ("hideZombie");
		currentZombies -= 1;
	}

	void attack() {
		RaycastHit[] r_hits = Physics.SphereCastAll(new Ray (transform.position, transform.forward), 3, 3);
		//Debug.Log ("Attack");


		//if (Physics.SphereCastAll (new Ray (transform.position, transform.forward), 3, out r, 3).Length >0) {

			foreach (RaycastHit r in r_hits) {
			if (r.collider.gameObject.tag == "Human") {
						Destroy (r.collider.gameObject);
						Debug.Log ("Hit");
						addZombie ();
				}
		}


	}
	// Update is called once per frame
	void Update () {
		timeSinceAttack += Time.deltaTime;

		if (timeSinceAttack > attackInterval) {

			attack();
			timeSinceAttack = 0;

		}


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
}
