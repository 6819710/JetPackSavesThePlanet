﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CoinSoundEffectController))]
public class CoinPickupBehavior : PickupBehaviour {

	public int pointsGranted;

	public override void onPickup ()
	{
		GameManager.instance.GetComponent<ScoreManager> ().Score += pointsGranted;
		GetComponent<Animator> ().SetTrigger ("Disappear");
	}

}