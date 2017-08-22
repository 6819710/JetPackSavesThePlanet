using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class ExplodeOnDeath : MonoBehaviour {

	public float explotionForce = 10f;
	public GameObject blood;

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
		RemoveJoints (this.transform);
		if (blood != null) {
			GameObject bp = Instantiate (blood);
			bp.transform.position = this.gameObject.transform.position;
			bp.transform.parent = this.gameObject.transform;
		}
	}

	public void RemoveJoints(Transform of){
		Joint2D j = of.gameObject.GetComponent<Joint2D> ();
		if (j != null) Destroy (j);
		for(int i=0; i < of.childCount; i++){
			Transform t = of.GetChild (i);
			RemoveJoints (t);
		}
		AddExplosionForce (of.gameObject);
	}

	public void AddExplosionForce(GameObject to){
		Rigidbody2D rb = to.GetComponent<Rigidbody2D> ();
		if (rb != null) {
			rb.AddForce (Random.insideUnitCircle * explotionForce);
			rb.AddTorque (Random.Range(-1,1));
		}
	}
}
