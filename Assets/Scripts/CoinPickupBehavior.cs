using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CoinPickupBehavior : PickupBehaviour {

	public int pointsGranted;

	void Start(){
	}

	public override void onPickup ()
	{
		GameManager.instance.GetComponent<ScoreManager> ().Score += pointsGranted;
		GetComponent<Animator> ().SetTrigger ("Disappear");
	}

}
