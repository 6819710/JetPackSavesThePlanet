using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpawnableObject))]
public class Asteroid : DestructableEntity {

    public SpawnableObject objectToSplitInto;
    public int minPiecesCount;
    public int maxPiecesCount;
    public float minExplosionForce;
    public float maxExplosionForce;
    public float splitDistance;
    public float maxSpawnAngleDeviationFactor;

	public List<String> canBeDestroyedBy;

    public int oxygenValue;

	public UnityEvent onSplit;

	public List<String> CanBeDestroyedBy {
		get {
			return canBeDestroyedBy;
		}
		set {
			canBeDestroyedBy = value;
		}
	}


    // Use this for initialization
    new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
    }

    public void Split(Vector2 normal) {
		onSplit.Invoke ();
        if (objectToSplitInto) SplitIntoObjects(normal, objectToSplitInto, minPiecesCount, maxPiecesCount);
    }

    protected void SplitIntoObjects(Vector2 normal, SpawnableObject obj, int minPiecesCount, int maxPiecesCount) {
        var piecesCount = UnityEngine.Random.Range(minPiecesCount, maxPiecesCount+1);
        var initialDirection = Quaternion.Euler(0, 0, 90) * normal;
        for (int i=0; i < piecesCount; i++) {

            var angleDeviation = UnityEngine.Random.Range(-1f, 1f)* maxSpawnAngleDeviationFactor;
            var nextDirection = Quaternion.Euler(0, 0, (i+ angleDeviation) * 360/piecesCount) * initialDirection;
            var spawnedObj = GetComponent<SpawnableObject>().GetSpawner().SpawnObject(obj, transform.position + nextDirection * splitDistance, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
            var force = nextDirection * UnityEngine.Random.Range(minExplosionForce, maxExplosionForce) * spawnedObj.GetComponent<Rigidbody2D>().mass;
            spawnedObj.GetComponent<Rigidbody2D>().AddForce(force * Time.deltaTime);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
		if (!IsSpawnProtected()) {
            if (collision.gameObject.GetComponent<Asteroid>()) {
                float energy = collision.relativeVelocity.sqrMagnitude * collision.otherRigidbody.mass/2;
                TakeDamage(energy);
			} else if(canBeDestroyedBy.Contains(collision.gameObject.tag)) { // TODO Gavin: remove hardcoded tags; Isuru : Done
                currentHealth = 0;
            }
           
            if (currentHealth <= 0) {
                Split(collision.contacts[0].normal);
                Destruct();
            }
        }
    }
}
