using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour {

    public SpawnableObject[] spawnableObjects;
    public List<SpawnableObject> instantiatedObjects;

    // TODO Gavin: Random table implementation (@xxfast do you have an implementation?)
    protected SpawnableObject GetRandomSpawnableObject() {
        return spawnableObjects[Mathf.RoundToInt(Random.Range(0, spawnableObjects.Length))];
    }

    public SpawnableObject SpawnRandomObject(Vector3 pos, Quaternion rot) {
        var instantiatedObject = SpawnObject(GetRandomSpawnableObject(), pos, rot);
        return instantiatedObject;
    }

    // If you are cloning a Component then the GameObject it is attached to will also be cloned, again with an optional position and rotation.
    public SpawnableObject SpawnObject(SpawnableObject obj, Vector3 pos, Quaternion rot) {
        var instantiatedObject = Instantiate(obj, pos, rot, transform);
        instantiatedObject.SetSpawner(this);
        instantiatedObjects.Add(instantiatedObject);
        return instantiatedObject;
    }

    //If an object is destroyed or despawned instead of being despawned by the spawner it can call this method to make sure the spawner removes it's reference
    public void HandleDestroyedObject(SpawnableObject despawnedObject) {
        instantiatedObjects.Remove(despawnedObject);
    }
}
