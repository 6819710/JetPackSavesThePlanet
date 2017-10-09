using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour {

    public ObjectSpawner spawner;

    public ObjectSpawner GetSpawner() {
        return spawner;
    }

    public void SetSpawner(ObjectSpawner spawner) {
        this.spawner = spawner;
    }

    protected void OnDestroy() {
        if (spawner)
            spawner.HandleDestroyedObject(this);
    }
}
