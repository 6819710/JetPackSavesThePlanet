using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	public GameState state;

	public GameState State {
		get {
			return state;
		}
		set {
			state = value;
		}
	}

	void Start () {
		state = GameState.Loading;
	}

	public void Change(GameState toChange){
		State = toChange;
	}

}
