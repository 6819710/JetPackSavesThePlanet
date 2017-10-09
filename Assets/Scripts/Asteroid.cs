using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpawnableObject))]
public class Asteroid : DestructableEntity {

    public List<SpawnableObject> objectToSplitInto;

    public float minExplosionForce;
    public float maxExplosionForce;
    public float splitDistance;
    public float maxSpawnAngleDeviationFactor;

	public List<string> canBeDestroyedBy;

    public int oxygenValue;

	public UnityEvent onSplit;

	public List<string> CanBeDestroyedBy {
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
		if (objectToSplitInto.Count>0) SplitIntoObjects(normal, objectToSplitInto);
    }

	protected void SplitIntoObjects(Vector2 normal, List<SpawnableObject> objectToSplitInto) {
       var initialDirection = Quaternion.Euler(0, 0, 90) * normal;
		foreach(SpawnableObject pieces in objectToSplitInto){
            var angleDeviation = UnityEngine.Random.Range(-1f, 1f)* maxSpawnAngleDeviationFactor;
			var nextDirection =  initialDirection + Random.insideUnitSphere;
			var spawnedObj = GetComponent<SpawnableObject>().GetSpawner().SpawnObject(pieces, transform.position + nextDirection * splitDistance, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));
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
