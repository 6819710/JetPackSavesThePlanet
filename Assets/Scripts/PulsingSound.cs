using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CrateSoundController))]
public class PulsingSound : MonoBehaviour {

	public float pulseFrequency = 1; // time in seconds for each pulse

	private CrateSoundController sfx;
	private float time;

	// Use this for initialization
	void Start () {
		time = pulseFrequency;
		sfx = this.gameObject.GetComponent<CrateSoundController> ();
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			sfx.Play (CrateSoundController.SoundEffect.Ping);
			time = pulseFrequency;
		}

	}

}
