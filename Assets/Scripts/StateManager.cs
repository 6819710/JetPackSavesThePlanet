using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
		currentState = GameState.Menu;
	}

	public void Restart(){
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void Play(){
		Change (GameState.Playing);
	}

	public void Pause(){
		Change (GameState.Paused);
	}

	public void Lost(){
		Change (GameState.Lost);
	}

	public void Change(GameState toChange){
		currentState = toChange;
	}



}
