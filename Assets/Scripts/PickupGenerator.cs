using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour {

	public void SpawnPickup(GameObject what){
		GameObject spawned = Instantiate (what);
		spawned.transform.position = Random.insideUnitCircle * 100;
	}

	public void SpawnPickup(GameObject what, Vector2 position){
		GameObject spawned = Instantiate (what);
		spawned.transform.position = position;
	}

}
