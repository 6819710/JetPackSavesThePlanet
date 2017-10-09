using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingSound : MonoBehaviour {

	private CrateSoundController sfx;

	// Use this for initialization
	void Start () {
		sfx = this.GetComponentInChildren<CrateSoundController>();
	}

	public void Ping ()
	{
		sfx.Play(CrateSoundController.SoundEffect.Spawn);
	}

}
