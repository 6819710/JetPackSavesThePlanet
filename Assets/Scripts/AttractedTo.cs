using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttractedTo : MonoBehaviour {

	public string to;
	public float force = 1f; 
	public float range = 100f;

	public GameObject target;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectsWithTag (to)[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (to != null) {
			Vector3 forceDirection = transform.position - target.transform.position;
			if(forceDirection.magnitude > range)
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(-forceDirection.normalized * force * Time.fixedDeltaTime);
		}
	}
}
