using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAsteroid : Asteroid {

	// Use this for initialization
	new void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    new protected void OnCollisionEnter2D(Collision2D collision) {
        if (!IsSpawnProtected()) {

            if (collision.gameObject.GetComponent<Asteroid>()) {
                float energy = collision.relativeVelocity.sqrMagnitude * collision.otherRigidbody.mass / 2;
                TakeDamage(energy);
            }
			else if (CanBeDestroyedBy.Contains( collision.gameObject.tag)) { // TODO Gavin: remove hardcoded tags, Isuru: Done
                currentHealth = 0;
            }

            if (currentHealth <= 0) {
                Split(collision.contacts[0].normal);
                Destruct();
            }
        }
    }
}
