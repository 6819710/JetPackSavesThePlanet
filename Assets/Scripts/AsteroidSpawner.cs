using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidSpawner : ObjectSpawner {

    public Transform generateAround;
    public float maxObjectCount;
    public float spawnRange;
    public float despawnRange;

	// Use this for initialization
	void Start () {
        instantiatedObjects = new List<SpawnableObject>();
    }
	
	// Update is called once per frame
	void Update () {
        DespawnObjectsOutsideRange(despawnRange);
        SpawnAsteroids(spawnRange, despawnRange);
    }

    private void DespawnObjectsOutsideRange(float range) {
        // Destroys objects beyond despawnRange from generateAround.position
        List<SpawnableObject> objectsOutOfRange = instantiatedObjects.Where(obj => Vector3.Distance(obj.transform.position, generateAround.position) > range ).ToList();
        objectsOutOfRange.ForEach(obj => Destroy(obj.gameObject));
    }

    // (Hardcoded) all objects spawned by this script are asteroids
    private void SpawnAsteroids(float minSpawnRange, float maxSpawnRange) {
        var asteroidCount = instantiatedObjects.Count;
        for (var i = 0; asteroidCount < maxObjectCount && i < maxObjectCount; i++) {
            var pos = (Random.Range(0, minSpawnRange - maxSpawnRange) + maxSpawnRange) * (Vector3)Random.insideUnitCircle.normalized + generateAround.position;
            var rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
            SpawnRandomObject(pos, rot);
            asteroidCount++;
        }
    }
}
