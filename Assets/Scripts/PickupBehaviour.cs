using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class PickupBehaviour : MonoBehaviour {

	public List<string> canbePickedUpBy;

	private void OnCollisionEnter2D(Collision2D collision) {
		if(canbePickedUpBy.Contains(collision.gameObject.tag)){
			onPickup ();
		}
	}

	public abstract void onPickup ();
}
