using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormGenerator : MonoBehaviour {
	 

	public bool autoGenerate = false;
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
		if(autoGenerate){
			time -= Time.deltaTime;
			if (time < 0) {
				time = spawnFrequency;
				SpawnWorm ();
			}
		}
	}

	private void GenerateWorm(float distance){
		GameObject spawned = Instantiate (Worm);
		spawned.transform.position = targeting.transform.position - (Random.insideUnitSphere * distance);
		spawned.GetComponentInChildren<WormHead> ().mainTarget = targeting.transform;
		spawned.GetComponentInChildren<WormHead> ().isDebug = false;
	}

	public void SpawnWorm(){
		GenerateWorm (spawnDistance);
	}

	public void SpawnWorm(float distance){
		GenerateWorm (distance);
	}
}
