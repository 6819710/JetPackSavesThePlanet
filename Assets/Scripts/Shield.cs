using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	private ShieldSFXControler sfx;

	void Start(){
		sfx = gameObject.GetComponentInChildren<ShieldSFXControler> ();
	}

	void OnCollisionEnter2D (Collision2D other) {
		sfx.playRandom ();
	}

	void DestroyShield () {
		Destroy (this.gameObject);
	}
}
