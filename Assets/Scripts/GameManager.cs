using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(ScreenManager))]
[RequireComponent(typeof(CameraManager))]
[RequireComponent(typeof(LevelManager))]
public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject Director = null;
	public GameObject Player = null;

	//managers 
	private StateManager stateManager; 
	private ScoreManager scoreManager;
	private ScreenManager screenManager;
	private CameraManager cameraManager;
	private LevelManager levelManager;

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
		Application.targetFrameRate = 60;
		Initialise ();
		shown = StateManager.CurrentState;
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
		if (levelManager == null) {
			levelManager = this.GetComponent<LevelManager> ();
		}
	}

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject); 
		//DontDestroyOnLoad(gameObject); singleton behavior result lost of references. 
	}

	void Update(){
		if (shown == GameState.Menu) {
			if (Player.GetComponent<Movement> ().isMoving) {
				StateManager.Play ();
			}
			shown = StateManager.CurrentState;
		}
	}

	public void Begin(){
		stateManager.Play ();
		levelManager.Begin();
	}
}
