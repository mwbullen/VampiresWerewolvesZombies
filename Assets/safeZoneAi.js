#pragma strict

public var Health:float = 100f;
public var Capacity:int = 50;
public var 	humanCount:int =0;
	
function Start () {

}

function Update () {

}

function addHuman() {
	humanCount +=1;
	
}

function takeDamage(damage:int) {
	Health -= damage;
	
	if (Health <= 0 ) {
		breakOpen();
	}
}

function breakOpen() {
	for (var i:int = 0; i < humanCount; i++) {
			Camera.main.SendMessage("createHuman", transform.position);
	}
	
		Destroy (gameObject);
}