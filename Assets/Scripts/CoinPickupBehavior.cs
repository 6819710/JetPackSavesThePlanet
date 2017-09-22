using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CoinPickupBehavior : PickupBehaviour {

	public int pointsGranted;

	private SFXControler sfxPlayer;

	void Start(){
		if (sfxPlayer == null) {
			sfxPlayer = GameObject.Find ("SFX").GetComponent<SFXControler>();
		}
	}

	public override void onPickup ()
	{
		GameManager.instance.GetComponent<ScoreManager> ().Score += pointsGranted;
		GetComponent<Animator> ().SetTrigger ("Disappear");
		sfxPlayer.playCoinCollect ();
	}

}
