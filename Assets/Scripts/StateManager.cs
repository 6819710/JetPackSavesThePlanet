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
		currentState = GameState.Menu;
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		GameManager.instance.Initialise ();
	}

	public void Play(){
		Change (GameState.Playing);
	}

	public void Pause(){
		Change (GameState.Paused);
	}

	public void Lost(DeathTypes cause){
        if (cause == DeathTypes.Worm)
            GameObject.Find("SFX").SendMessage("playDeathByWorm");
        else if (cause == DeathTypes.Suffocate)
            GameObject.Find("SFX").SendMessage("playDeathByOxygen");

        GameObject.Find("Music").SendMessage("toSilence"); // Fade to Silence

        Change (GameState.Lost);
    }

	public void Change(GameState toChange){
		currentState = toChange;
	}



}
