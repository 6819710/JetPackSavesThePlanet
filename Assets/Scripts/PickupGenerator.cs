using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour {
	
	public Transform around;
	public float distance = 10;

	public void SpawnPickup(GameObject what){
		SpawnPickup (what, distance);
	}

	public void SpawnPickup(GameObject what, float distace){
		GameManager.instance.GetComponent<TutorialManager> ().SetTrigger (TutorialManager.TutorialTriggers.PickupSpawned);
		GameObject spawned = Instantiate (what);
		spawned.transform.position = around.position - (Random.insideUnitSphere * distance);
	}

}
