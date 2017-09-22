using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntOnCollision : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other) {
		StuntingBehavior sb = other.collider.gameObject.GetComponent<StuntingBehavior> ();
		if (sb != null)
			sb.Stunt ();
	}
}
