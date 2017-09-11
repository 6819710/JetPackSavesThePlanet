using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class PlayerManager : MonoBehaviour {

	public GameObject player;

	private StateManager stateManager;
	private Health playerHealth;

	public GameObject this [int i]
	{
		get { return player; }
	}

	void Start () {
		Initialise ();
	}

	void Update(){
		switch (stateManager.currentState) {
		case GameState.Playing:
			if (playerHealth.isDead)
				stateManager.Lost ();
			break;
		default:
			break;
		}
	}

	public void Initialise ()
	{
		if (player == null)
			player = GameObject.Find ("Player");
		playerHealth = player.GetComponent<Health> ();
		stateManager = gameObject.GetComponent<StateManager> ();
	}

}
