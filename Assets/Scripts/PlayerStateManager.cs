using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Suffocate))]
public class PlayerStateManager : MonoBehaviour {

	public PlayerState state = PlayerState.Idle;

	private Health health;
	private Suffocate suffocate;

	public PlayerState State {
		get {
			return state;
		}
		set {
			state = value;
		}
	}

	void Start(){
		health = this.gameObject.GetComponent<Health> ();
		suffocate = this.gameObject.GetComponent<Suffocate> ();
	}

	void Update(){
		if (health.isDead) 
			Dead ();
		else if (suffocate.isSuffocating)
			Suffocating ();
		else
			Idle ();
	}
	
	public void Idle(){
		state = PlayerState.Idle;
	}

	public void Happy(){
		state = PlayerState.Happy;
	}

	public void Panic(){
		state = PlayerState.Panic;
	}

	public void Suffocating(){
		state = PlayerState.Suffocating;
	}

	public void Dead(){
		state = PlayerState.Dead;
	}
}
