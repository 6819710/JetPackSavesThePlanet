using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	public GameState currentState;

	public GameState CurrentState {
		get {
			return currentState;
		}
		set {
			currentState = value;
		}
	}

	void Start () {
		currentState = GameState.Loading;
	}

	public void Play(){
		Change (GameState.Playing);
	}

	public void Change(GameState toChange){
		currentState = toChange;
	}



}
