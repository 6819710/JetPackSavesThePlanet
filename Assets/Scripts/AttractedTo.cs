using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedTo : MonoBehaviour {

	public string to;
	public float force = 1f; 

	public GameObject target;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectsWithTag (to)[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (to != null) {
			this.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position,  target.transform.position, force);
		}
	}
}
