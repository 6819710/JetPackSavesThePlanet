using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class CameraManager : MonoBehaviour {

	private StateManager sm;
	private GameState shown;
	private Animator mainCameraAnimator;

	void Start () {
		sm = gameObject.GetComponent<StateManager> ();
		shown = sm.CurrentState;
		mainCameraAnimator = Camera.main.GetComponent<Animator> ();
		if (mainCameraAnimator==null) throw new UnityException ("Main Camera Require an Animator component for the Camera manager to work");
	}
	
	// Update is called once per frame
	void Update () {
		if (shown != sm.CurrentState) {
			shown = sm.CurrentState;
			switch(shown){
				case GameState.Menu:
					Camera.main.GetComponent<Animator> ().SetTrigger ("Paused");
					break;
				case GameState.Lost:
					Camera.main.GetComponent<Animator> ().SetTrigger ("Deadcam");
					break;
				case GameState.Playing:
					Camera.main.GetComponent<Animator> ().SetTrigger ("Gameplay");
					break;
			}
		}
	}
}
