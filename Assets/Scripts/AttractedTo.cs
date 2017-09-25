using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttractedTo : MonoBehaviour {

	public string to;
	public float startingForce = 1f;
    public float acceleration = 1f;
    private float additionalForce = 0f;
	public float range = 100f;

	public GameObject target;


	// Use this for initialization
	void Start () {
		target = GameObject.Find (to);
	}
	
	// Update is called once per frame
	void Update () {
		if (to != null) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position , (startingForce + additionalForce)*Time.deltaTime);
            additionalForce += acceleration * Time.deltaTime;
		}
	}
}
