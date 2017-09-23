using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class ScreenManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject inGame;
	public GameObject gameOver;
	public GameObject pause;

	private List<GameObject> screens;
	private StateManager sm;
	public GameState shown;

	void Start () {
		Initialise ();
		shown = sm.CurrentState;
	}
	
	void Update () {
		if (shown != sm.CurrentState){
			shown = sm.CurrentState;
			GameObject state = mainMenu;
			switch (sm.CurrentState) {
				case GameState.Menu:
					state = mainMenu;
					break;
				case GameState.Playing:
					state = inGame;
					break;
			case GameState.Paused:
					state = pause;
					break;
				case GameState.Lost:
					state = gameOver;
					break;
			}
			state.SetActive (true);
			Enter (state);
			TransitExcept (state);
		}
	}

	public void Initialise(){
		sm = gameObject.GetComponent<StateManager> ();
		if (mainMenu == null)
			mainMenu = GameObject.Find ("Main Menu Screen");
		if (inGame == null)
			mainMenu = GameObject.Find ("In Game Screen");
		if (gameOver == null)
			mainMenu = GameObject.Find ("Game Over Screen");
		if (pause == null)
			mainMenu = GameObject.Find ("Pause Screen");
		screens = new List<GameObject> (){mainMenu, inGame,gameOver,pause};
	}

	void Enter(GameObject what){
		Animator anim = what.GetComponent<Animator> ();
		anim.SetTrigger ("Enter");
	}

	void TransitExcept(GameObject what){
		foreach(GameObject screen in screens){
			if (screen != what) {
				Animator anim = screen.GetComponent<Animator> ();
				if(anim!=null){
					anim.SetTrigger ("Transit");
				}
			}
		}
	}
}
