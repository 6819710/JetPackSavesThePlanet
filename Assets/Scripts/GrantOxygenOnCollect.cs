using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GrantOxygenOnCollect : MonoBehaviour {

	public List<string> canBeCollectedByEntitesTagged;
	public Oxygen self;

	void Awake(){
		if (canBeCollectedByEntitesTagged!=null)
			canBeCollectedByEntitesTagged = new List<string> ();
		self = gameObject.GetComponent<Oxygen>();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(canBeCollectedByEntitesTagged.Contains(collision.gameObject.tag)){
			// Trigger Oxygen Replenishment
			Oxygen oxygen = collision.gameObject.GetComponent<Oxygen>();
			if (oxygen != null && self != null) oxygen.ApplyDelta(self.oxygen);
		}
	}
}
