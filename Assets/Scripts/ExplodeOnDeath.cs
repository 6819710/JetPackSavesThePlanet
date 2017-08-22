using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class ExplodeOnDeath : MonoBehaviour {

	public float explotionForce = 10f;

	private bool exploded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Health> ().isDead && !exploded) {
			Explode ();
			exploded = true;
		}
	}

	public void Explode(){
		for(int i=0; i < this.transform.childCount; i++){
			Transform t = this.transform.GetChild (i);
			Joint2D j = t.gameObject.GetComponent<Joint2D> ();
			if (j != null) Destroy (j);
			Rigidbody2D rb = t.GetComponent<Rigidbody2D> ();
			if (rb != null) {
				rb.AddForce (Random.insideUnitCircle * explotionForce);
				rb.AddTorque (Random.Range(-1,1));
			}
		}
	}
}
