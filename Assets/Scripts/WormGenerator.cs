using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGenerator : MonoBehaviour {
	 
	public float spawnFrequency = 100f;
	public float spawnDelay = 10f;
	public float spawnDistance = 10f;
	public GameObject spawnAround;
	public GameObject Worm;
	public GameObject targeting;

	private float time;

	// Use this for initialization
	void Start () {
		time = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			time = spawnFrequency;
			SpawnWorm ();
		}
	}

	void SpawnWorm(){
		GameObject spawned = Instantiate (Worm);
		spawned.transform.position = Random.insideUnitCircle * spawnDistance;
		spawned.GetComponentInChildren<WormHead> ().mainTarget = targeting.transform;
		spawned.GetComponentInChildren<WormHead> ().isDebug = false;
	}
}
