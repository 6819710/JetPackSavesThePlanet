using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameObject player;

	public GameObject this [int i]
	{
		get { return player; }
	}

	void Start () {
		Initialise ();
	}

	public void Initialise ()
	{
		if (player == null)
			player = GameObject.Find ("Player");
	}

}
