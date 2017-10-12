using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour {

    public SpawnableObject[] spawnableObjects;
    public List<SpawnableObject> instantiatedObjects;

	public List<SpawnableObject> InScreen{
		get{
			List<SpawnableObject> toReturn = new List<SpawnableObject> ();
			foreach (SpawnableObject obj in instantiatedObjects) {
				Vector3 screenPoint = Camera.main.WorldToViewportPoint(obj.gameObject.transform.position);
				if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) {
					toReturn.Add (obj);
				}
			}
			return toReturn;
		}
	}

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
