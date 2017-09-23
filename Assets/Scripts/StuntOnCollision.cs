using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundEffectsController))]
public class StuntOnCollision : MonoBehaviour {

	private SoundEffectsController sfx;

	void Start(){
		sfx = gameObject.GetComponent<SoundEffectsController> ();
	}

	void OnCollisionEnter2D (Collision2D other) {
		StuntingBehavior sb = other.collider.gameObject.GetComponent<StuntingBehavior> ();
		if (sb != null)
			sb.Stunt ();
		sfx.Play ();
	}
}
