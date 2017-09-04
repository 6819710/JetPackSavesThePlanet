using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class ScreenManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject inGame;
	public GameObject gameOver;

	private List<GameObject> screens;
	private StateManager sm;
	public GameState shown;

	void Start () {
		sm = gameObject.GetComponent<StateManager> ();
		screens = new List<GameObject> (){mainMenu, inGame,gameOver};
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
				case GameState.Lost:
					state = gameOver;
					break;
			}
			state.SetActive (true);
			TransitExcept (state);
		}
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
