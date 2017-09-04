using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

    public Transform generateAround;
    public GameObject[] asteroidPrefabs;
    public List<GameObject> instantiatedObjects;
    public float maxObjectCount;
    public float spawnRange;
    public float despawnRange;

	// Use this for initialization
	void Start () {
        instantiatedObjects = new List<GameObject>();
        DestroyObjectsOutsideDespawnRange();
        SpawnAsteroids(spawnRange, despawnRange);
    }
	
	// Update is called once per frame
	void Update () {
        DestroyObjectsOutsideDespawnRange();
        SpawnAsteroids(spawnRange, despawnRange);
    }

    private void DestroyObjectsOutsideDespawnRange() {
        // Destroys objects beyond despawnRange from generateAround.position
        List<GameObject> objectsToRemove = new List<GameObject>();
        foreach (var obj in instantiatedObjects) {
            if (!obj || Vector3.Distance(obj.transform.position, generateAround.position) > despawnRange) {
                objectsToRemove.Add(obj);
            }
        }
        foreach (var obj in objectsToRemove) {
            if (instantiatedObjects.Remove(obj))
                Destroy(obj.gameObject);
        }
    }

    // (Hardcoded) all objects spawned by this script are asteroids
    private void SpawnAsteroids(float minSpawnRange, float maxSpawnRange) {
        var asteroidCount = instantiatedObjects.Count;
        for (var i = 0; asteroidCount < maxObjectCount && i < maxObjectCount; i++) {
            var asteroid = Instantiate(asteroidPrefabs[Mathf.RoundToInt(Random.Range(0, asteroidPrefabs.Length - 1))], (Random.Range(0, minSpawnRange - maxSpawnRange) + maxSpawnRange) * (Vector3)Random.insideUnitCircle.normalized + generateAround.position, Quaternion.Euler(0, 0, Random.Range(0, 360)), transform);
            asteroidCount++;
            instantiatedObjects.Add(asteroid);
        }
    }
}
