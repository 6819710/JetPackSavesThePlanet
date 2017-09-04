using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject Director = null;
	public GameObject Player = null;

	private StateManager stateManager; 
	private GameState shown;

	public StateManager StateManager {
		get {
			return stateManager;
		}
		set {
			stateManager = value;
		}
	}

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject); 

		DontDestroyOnLoad(gameObject);
		stateManager = this.GetComponent<StateManager> ();
	}

	
	// Update is called once per frame
	void Update () {
		if (shown != stateManager.CurrentState){
			shown = stateManager.CurrentState;
			switch (stateManager.CurrentState) {
			case GameState.Menu:
				break;
			case GameState.Playing:
				Time.timeScale = 1;
				Director.GetComponent<WormGenerator> ().enabled = true;
				break;
			case GameState.Paused:
				Time.timeScale = 0;
				break;
			case GameState.Lost:
				break;
			}
		}
	}
}
