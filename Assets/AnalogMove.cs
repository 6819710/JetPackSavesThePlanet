using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogMove : MonoBehaviour {

	public Vector3 direction;
	public float acceleration; 

	void FixedUpdate () {
		direction = new Vector3( Input.GetAxis ("Horizontal"),  Input.GetAxis ("Vertical"), 0);
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * acceleration, ForceMode2D.Impulse);
	}
}
