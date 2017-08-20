using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyCameraLookAhead : MonoBehaviour {

	public float howFarToLookAhead = 5f;
	public float lazinessFactor = 0.5f;
	public float minimumCutoff = 1f;
	public GameObject target;

	void Start(){
	}

	void Update () {
		// Camera follows only if the target is assigned
		if (target!=null) {
			Vector3 velocity = Vector3.zero;
			Vector3 targetVelocity = (target.GetComponent<Rigidbody2D> ().velocity.normalized);
			Vector3 direction = Vector3.ClampMagnitude (((targetVelocity.magnitude > minimumCutoff)  ? targetVelocity * howFarToLookAhead : Vector3.zero) , howFarToLookAhead);
			Vector3 needPos = target.transform.position + direction;
			needPos.z = transform.position.z;
			transform.position = Vector3.LerpUnclamped(transform.position, needPos, lazinessFactor);
			transform.LookAt (target.transform);
			transform.rotation = target.transform.rotation;
		}
	}
}
