using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateManager))]

public class Reactions : MonoBehaviour {
	private PlayerStateManager playerStateManager;
	private Animator headAnimator;

	private PlayerState shown;

	void Start () {
		playerStateManager = gameObject.GetComponent<PlayerStateManager> ();
		shown = playerStateManager.State;
		headAnimator = transform.Find ("head").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(shown != playerStateManager.State){
			shown = playerStateManager.State;
			switch(shown){
				case PlayerState.Idle:
					headAnimator.SetTrigger ("Idle");
					break;
				case PlayerState.Happy:
					headAnimator.SetTrigger ("Happy");
					break;
				case PlayerState.Suffocating:
					headAnimator.SetTrigger ("Suffocating");
					break;
				case PlayerState.Panic:
					headAnimator.SetTrigger ("Panic");
					break;
				case PlayerState.Dead:
					headAnimator.SetTrigger ("Dead");
					break;
			}
		}
	}
}
