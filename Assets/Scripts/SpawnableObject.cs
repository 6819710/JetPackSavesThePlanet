using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour {

    protected ObjectSpawner spawner;

    // Use this for initialization
    protected void Start () {
		
	}

    // Update is called once per frame
    protected void Update () {
		
	}

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
