using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Oxygen))]
public class GrantOxygenOnCollect : MonoBehaviour {

	public int grantingRate = 1;

	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

	private Oxygen self;

	void Awake(){
		self = gameObject.GetComponent<Oxygen>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(canBeCollectedByEntitesTagged.Contains(collision.gameObject.tag)){
			// Trigger Oxygen Replenishment
			Oxygen oxygen = collision.gameObject.GetComponent<Oxygen>();
			if (!self.isOut) {
				if (oxygen != null && self != null) {
					self.oxygen -= grantingRate;
					oxygen.ApplyDelta (grantingRate);
				}
			}
		}
	}
}
