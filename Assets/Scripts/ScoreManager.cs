using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int iceAsteroidsDestroyed = 0;
	public float timeSpent = 0;

	private StateManager stateManager;

	public int IceAsteroidsDestroyed {
		get {
			return iceAsteroidsDestroyed;
		}
		set {
			iceAsteroidsDestroyed = value;
		}
	}

	public bool isKeepingScore{
		get { 
			return (stateManager.CurrentState == GameState.Playing) 
			&& !GameManager.instance.Player.GetComponent<Health> ().isDead; 
		}
	}

	public string TimeSpent{
		get { 
			int seconds =  (int)timeSpent % 60;
			int minutes = (int) timeSpent / 60;
			return string.Format("{0:00}:{1:00}",minutes,seconds);
		}
	}

	void Start () {
		Initialise ();
		stateManager = gameObject.GetComponent<StateManager> ();
	}

	void Update(){
		if(isKeepingScore)
			timeSpent+= Time.deltaTime;
	}

	public void Initialise(){
	}

}
