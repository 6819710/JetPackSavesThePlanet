using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Oxygen))]
[RequireComponent(typeof(Rigidbody2D))]
public class GrantOxygenOnCollect : MonoBehaviour {

	public float grantDelay = 10; // time to wait before granting oxygen;
	public int grantingRate = 1; // rate at which oxygen is granted;

	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

	private Oxygen self;
	private float time;

	void Awake(){
		self = gameObject.GetComponent<Oxygen>();
	}

	void Start(){
		time = grantDelay;
	}

	void Update(){
		if(time>0) time -= Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D collision) {
		if(time<=0 && canBeCollectedByEntitesTagged.Contains(collision.gameObject.tag)){
			// Trigger Oxygen Replenishment, if the reciever has one
			Oxygen oxygen = collision.gameObject.GetComponent<Oxygen>();
			if (oxygen!=null && !self.isOut) {
				if (oxygen != null && self != null) {
					self.oxygen -= grantingRate;
					oxygen.ApplyDelta (grantingRate);
				}
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (time <= 0 && canBeCollectedByEntitesTagged.Contains (collision.gameObject.tag)) {
			//Trigger Soundeffects , If the reciever has an audio source
			SoundEffectsController sfx = collision.gameObject.GetComponent<SoundEffectsController> ();
			if (sfx != null && sfx is PlayerSFXController) { // if it's players
				PlayerSFXController psfx = sfx as PlayerSFXController;
				psfx.Play (PlayerSFXController.SoundEffect.Oxygen);
			}
		}
	}
}
