using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour {
    // Refence Variables
    private Oxygen oxygenSupply;

    // Settings
    public float breathingRate; // How many frames need to pass between each use of oxygen

    // Misc
    private float timer;

	// Use this for initialization
	void Start () {
        oxygenSupply = this.gameObject.GetComponent<Oxygen>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (oxygenSupply != null)
        {
            if (timer >= breathingRate)
            {
                oxygenSupply.ApplyDelta(-1);
                timer = 0;
            }
            else
                timer += Time.deltaTime;
        }
	}
}
