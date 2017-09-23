using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject Director = null;
	public GameObject Player = null;

	//managers 
	private StateManager stateManager; 
	private ScoreManager scoreManager;
	private ScreenManager screenManager;
	private CameraManager cameraManager;

	private GameState shown;

	public StateManager StateManager {
		get {
			return stateManager;
		}
		set {
			stateManager = value;
		}
	}

	void Start(){
		Initialise ();
	}

	public void Initialise(){
		if(Player==null) Player = GameObject.Find ("Player");
		if(Director==null) Director = GameObject.Find ("Director");
		if (stateManager == null) {
			stateManager = this.GetComponent<StateManager> ();
		}
		if (scoreManager == null) {
			scoreManager = this.GetComponent<ScoreManager> ();
			scoreManager.Initialise ();
		}
		if (screenManager == null) {
			screenManager = this.GetComponent<ScreenManager> ();
			screenManager.Initialise ();
		}
		if (cameraManager == null) {
			cameraManager = this.GetComponent<CameraManager> ();
		}
	}

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject); 
		//DontDestroyOnLoad(gameObject); singleton behavior result lost of references. 
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
