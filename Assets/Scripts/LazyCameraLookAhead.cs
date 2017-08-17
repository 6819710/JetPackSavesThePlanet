﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyCameraLookAhead : MonoBehaviour {

	public float howFarToLookAhead = 5f;
	public float lazinessFactor = 0.5f;
	public GameObject target;

	void Update () {
		// Camera follows only if the target is assigned
		if (target!=null) {
			Vector3 velocity = Vector3.zero;
			Vector3 forward = target.transform.forward * 10.0f;
			Vector3 direction = target.GetComponent<Rigidbody2D> ().velocity;
			Vector3 needPos = target.transform.position - forward + (direction * howFarToLookAhead);
			transform.position = Vector3.SmoothDamp(transform.position, needPos, ref velocity, lazinessFactor);
			transform.LookAt (target.transform);
			transform.rotation = target.transform.rotation;
		}
	}
}
