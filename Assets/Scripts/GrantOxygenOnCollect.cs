using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Oxygen))]
public class GrantOxygenOnCollect : MonoBehaviour {

	public float grantDelay = 10; // time to wait before granting oxygen;
	public int grantingRate = 1; // rate at which oxygen is granted;

	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

	private Oxygen self;
	private float time;

	private GameObject sfxPlayer;

	void Awake(){
		self = gameObject.GetComponent<Oxygen>();
	}

	void Start(){
		time = grantDelay;
		sfxPlayer = GameObject.Find ("SFX");
	}

	void Update(){
		if(time>0) time -= Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D collision) {
		if(time<=0 && canBeCollectedByEntitesTagged.Contains(collision.gameObject.tag)){
			sfxPlayer.GetComponent<SFXControler> ().playOxygenSuck ();
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
