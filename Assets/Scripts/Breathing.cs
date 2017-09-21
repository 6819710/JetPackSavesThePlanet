using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour {
    // Refence Variables
    private Oxygen oxygenSupply;

    // Settings
    public float oxygenDrainPerSecond; // How much oxygen gets drained per second

	// Use this for initialization
	void Start () {
        oxygenSupply = this.gameObject.GetComponent<Oxygen>();
	}
	
	// Update is called once per frame
	void Update () {
        if (oxygenSupply != null)
        {
            float oxygenToDrain = oxygenDrainPerSecond * Time.deltaTime;
            oxygenSupply.ApplyDelta(-oxygenToDrain);
        }
	}
}
