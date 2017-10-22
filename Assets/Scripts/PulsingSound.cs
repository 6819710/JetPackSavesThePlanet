using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingSound : MonoBehaviour {

	private GameObject sfx;

	// Use this for initialization
	void Start () {
		sfx = GameObject.Find("PickupSFXController");
	}

	public void Ping ()
	{
		sfx.SendMessage("PlayCratePing");
	}

}
