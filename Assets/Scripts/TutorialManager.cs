using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	public GameObject tutorials;
	public GameObject astroidSlide;
	public GameObject wormSlide;
	public GameObject pickupSlide;

	private TutorialState state;

	public int State {
		get {
			return (int)state;
		}
		set{
			state = (TutorialState)value;
		}
	}	

	public bool isDone {
		get {
			return state == TutorialState.Done;
		}
	}


	// Use this for initialization
	void Start () {
		bool completed = PlayerPrefs.GetInt ("hasCompletedTutorial")>0;
		if (!completed) {
			tutorials.SetActive (!completed);
			state = (TutorialState) PlayerPrefs.GetInt ("completedTutorialState");
			EnableActiveState (!completed);
		}
	}

	public void SetTrigger(TutorialTriggers trigger){
		if (state == TutorialState.Asteroids) {
			if (trigger == TutorialTriggers.IceAstroidDestroyed) {
				state = TutorialState.WormsSpawned;
				astroidSlide.GetComponent<Animator> ().SetTrigger ("Close");
			}
		} else if (state == TutorialState.WormsSpawned) {
			if (trigger == TutorialTriggers.WormSpawned) {
				EnableActiveState (true);
				state = TutorialState.WormDespawned;
				wormSlide.GetComponent<Animator> ().SetTrigger ("Open");
			}
		}else if (state == TutorialState.WormDespawned) {
			if (trigger == TutorialTriggers.WormDespawned) {
				state = TutorialState.PickupSpawned;
				wormSlide.GetComponent<Animator> ().SetTrigger ("Close");
			}
		}else if (state == TutorialState.PickupSpawned) {
			if (trigger == TutorialTriggers.PickupSpawned) {
				EnableActiveState (true);
				state = TutorialState.Done;
				pickupSlide.GetComponent<Animator> ().SetTrigger ("Open");
			}
		}else if (state == TutorialState.Done) {
			if (trigger == TutorialTriggers.PickupCollected) {
				state = TutorialState.Done;
				pickupSlide.GetComponent<Animator> ().SetTrigger ("Close");
			}
		}
	}

	public void EnableActiveState(bool should){
		switch(state){
			case TutorialState.Asteroids:
				astroidSlide.SetActive (should);
				break;
			case TutorialState.WormsSpawned:
				wormSlide.SetActive (should);
				break;
			case TutorialState.PickupSpawned:
				pickupSlide.SetActive (should);
				break;
		}
	}

	public void SpawnStartingWorm(){
		if(state == TutorialState.Done){
			gameObject.GetComponent<GameManager> ().Director.GetComponent<WormGenerator> ().SpawnWorm (100);
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	private enum TutorialState : int { Asteroids =0, WormsSpawned=1, WormDespawned=2, PickupSpawned=3,  PickupCollected=4, Done=5 };
	public enum TutorialTriggers { IceAstroidDestroyed, WormSpawned, WormDespawned, PickupSpawned, PickupCollected };
}
