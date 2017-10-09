using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	private SoundEffectsController sfx;

	void Start(){
		sfx = gameObject.GetComponentInChildren<SoundEffectsController> ();
	}

	void OnCollisionEnter2D (Collision2D other) {
		sfx.PlayOnce ();
	}

	void DestroyShield () {
		Destroy (this.gameObject);
	}
}
