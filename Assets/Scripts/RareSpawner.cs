using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RareSpawner : ObjectSpawner {

	public Transform generateAround;
	public float spawnRange;
	public float despawnRange;
	public float zMin = -5;
	public float zMax = -10;
	public float tryFrequency;

	public float[] spawnableChances;
	private float time;

	void Start () {
		instantiatedObjects = new List<SpawnableObject>();
		time = tryFrequency;
	}

	void Update () {
		DespawnObjectsOutsideRange(despawnRange);
		time -= Time.deltaTime;
		if(time<=0){
			time = tryFrequency;
			for(int i=0; i< spawnableObjects.Length;i++){
				if(Random.value<spawnableChances[i]) SpawnRare(spawnRange, despawnRange);
			}
		}
	}
	private void DespawnObjectsOutsideRange(float range) {
		List<SpawnableObject> objectsOutOfRange = instantiatedObjects.Where(obj => Vector3.Distance(obj.transform.position, generateAround.position) > range ).ToList();
		objectsOutOfRange.ForEach(obj => Destroy(obj.gameObject));
	}
	public void SpawnRare(float minSpawnRange, float maxSpawnRange) {
		Vector3 pos = (Random.Range(0, minSpawnRange - maxSpawnRange) + maxSpawnRange) * (Vector3)Random.insideUnitCircle.normalized + generateAround.position;
		Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
		pos.z = Random.Range (zMin, zMax);
		SpawnableObject spawned = SpawnRandomObject(pos, rot);
		spawned.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = (int)pos.z;
	}
}
