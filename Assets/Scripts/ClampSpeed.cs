using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ClampSpeed : MonoBehaviour {

	public float maxSpeed = 1;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		ClampVelocity();
	}

	void FixedUpdate(){
		ClampVelocity();
	}

	public void ClampVelocity(){
		var rb = gameObject.GetComponent<Rigidbody2D>();
		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = rb.velocity.normalized*maxSpeed;
		}
	}

	public Vector2 ClampedForce(Rigidbody2D rb, Vector2 force){
		if(Time.deltaTime <=0)
			return Vector2.zero;
		
		var currentVelocity = rb.velocity;
		var deltaVelocity = force/rb.mass * Time.deltaTime;
		var nextVelocity = currentVelocity + deltaVelocity;
		if(nextVelocity.magnitude > maxSpeed){
			var desiredForce = maxSpeed*deltaVelocity.normalized/Time.deltaTime * rb.mass;
			return desiredForce;
		}
		return force;
	}

}
