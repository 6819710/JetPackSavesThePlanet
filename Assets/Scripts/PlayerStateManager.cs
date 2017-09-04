using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Oxygen))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Suffocate))]
public class PlayerStateManager : MonoBehaviour {

	public PlayerState state;

	private Health health;
	private Oxygen oxygen;
	private Suffocate suffocate;

	public PlayerState State {
		get {
			return state;
		}
		set {
			state = value;
		}
	}

	void Start () {
		oxygen = this.gameObject.GetComponent<Oxygen> (); 
		health = this.gameObject.GetComponent<Health> ();
		suffocate = this.gameObject.GetComponent<Suffocate> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health.isDead)
			state = PlayerState.Dead;
		else if (suffocate.isSuffocating)
			state = PlayerState.Suffocating;
		else if (oxygen.isLow)
			state = PlayerState.Panic;
		else
			state = PlayerState.Idle;
	}
}
