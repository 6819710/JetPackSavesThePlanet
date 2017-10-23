using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundSpawner : ObjectSpawner {

	public float zMin = -5;
	public float zMax = -10;

	public int maxCount;
	public float spawnRange;
	public float despawnRange;
	public Transform generateAround;

	void Start () {
		instantiatedObjects = new List<SpawnableObject>();
	}

	void Update () {
		DespawnObjectsOutsideRange(despawnRange);
		SpawnBackgrounds(spawnRange, despawnRange);
	}

	private void DespawnObjectsOutsideRange(float range) {
		// Destroys objects beyond despawnRange from generateAround.position
		List<SpawnableObject> objectsOutOfRange = instantiatedObjects.Where(obj => Vector3.Distance(obj.transform.position, generateAround.position) > range ).ToList();
		objectsOutOfRange.ForEach(obj => Destroy(obj.gameObject));
	}


	public void SpawnBackgrounds(float minSpawnRange, float maxSpawnRange) {
		var backgroundCount = instantiatedObjects.Count;
		for (var i = 0; backgroundCount < maxCount && i < maxCount; i++) {
			Vector3 pos = (Random.Range(0, minSpawnRange - maxSpawnRange) + maxSpawnRange) * (Vector3)Random.insideUnitCircle.normalized + generateAround.position;
			Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
			pos.z = Random.Range (zMin, zMax);
			SpawnableObject spawned = SpawnRandomObject(pos, rot);
			spawned.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = (int)pos.z;
			backgroundCount++;
		}
	}
}
