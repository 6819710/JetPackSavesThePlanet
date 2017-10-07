using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingSound : MonoBehaviour {

	private PickupSFXController sfx;

	// Use this for initialization
	void Start () {
        sfx = this.GetComponentInChildren<PickupSFXController>();
	}

	public void Ping ()
	{
        sfx.PlayCratePing();
	}

}
