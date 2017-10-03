using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CrateSoundController))]
public class PulsingSound : MonoBehaviour {

	private CrateSoundController sfx;

	// Use this for initialization
	void Start () {
		sfx = this.gameObject.GetComponent<CrateSoundController> ();
	}

	public void Ping ()
	{
		sfx.Play (CrateSoundController.SoundEffect.Ping);
	}

}
