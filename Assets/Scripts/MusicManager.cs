using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class MusicManager : MonoBehaviour {

	private MusicController musicController;
	private StateManager stateManager;

	public GameState shown;

	// Use this for initialization
	void Start () {
		GameObject music = this.transform.Find("Music").gameObject;
		if(music!=null){
			musicController = music.GetComponent<MusicController>();
		}
		stateManager = this.gameObject.GetComponent<StateManager> ();
		shown = stateManager.CurrentState;
	}
	
	// Update is called once per frame
	void Update () {
		if(shown!=stateManager.CurrentState){
			shown = stateManager.CurrentState;
			switch(shown){
				case GameState.Menu:
					musicController.toMenu ();
					break;
				case GameState.Playing:
					musicController.toMenu ();
					break;
				case GameState.Paused:
					musicController.toCalmBeat ();
					break;
			}
		}
		
	}
}
