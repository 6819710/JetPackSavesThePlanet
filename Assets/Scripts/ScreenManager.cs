using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class ScreenManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject inGame;

	private List<GameObject> screens;
	private StateManager sm;

	void Start () {
		sm = gameObject.GetComponent<StateManager> ();
		screens = new List<GameObject> (){mainMenu, inGame};
	}
	
	// Update is called once per frame
	void Update () {
		switch(sm.CurrentState){
			case GameState.Menu:
				mainMenu.SetActive (true);
				break;
			case GameState.Playing:
				inGame.SetActive (true);
				break;
		}
	}
}
