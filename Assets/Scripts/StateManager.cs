using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour {

	public GameState currentState;

	public UnityEvent onMenu;
	public UnityEvent onRestart;
	public UnityEvent onPlay;
	public UnityEvent onPause;
	public UnityEvent onLost;

	public GameState CurrentState {
		get {
			return currentState;
		}
		set {
			currentState = value;
		}
	}

	void Start () {
		Menu();
	}

	public void Restart(){
		currentState = GameState.Menu;
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		GameManager.instance.Initialise ();
		onRestart.Invoke ();
	}

	public void Menu(){
		Change (GameState.Menu);
		onMenu.Invoke ();
	}


	public void Play(){
		Change (GameState.Playing);
		onPlay.Invoke ();
	}

	public void Pause(){
		Change (GameState.Paused);
		onPause.Invoke ();
	}

	public void Lost(){
		Change (GameState.Lost);
		onLost.Invoke ();
	}

	public void Change(GameState toChange){
		currentState = toChange;
	}

	public void StopTime(bool should){
		Time.timeScale = ((should)?0:1);
	}



}
