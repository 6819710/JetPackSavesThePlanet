using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private StateManager stateManager; 

	public StateManager StateManager {
		get {
			return stateManager;
		}
		set {
			stateManager = value;
		}
	}

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject); 

		DontDestroyOnLoad(gameObject);
		stateManager = this.GetComponent<StateManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
