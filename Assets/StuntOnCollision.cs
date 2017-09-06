using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntOnCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		StuntingBehavior sb = other.GetComponent<StuntingBehavior> ();
		if (sb != null)
			sb.Stunt ();
	}
}
