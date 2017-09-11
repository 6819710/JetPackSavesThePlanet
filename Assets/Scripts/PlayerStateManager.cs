using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour {

	public PlayerState state = PlayerState.Idle;

	public PlayerState State {
		get {
			return state;
		}
		set {
			state = value;
		}
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
