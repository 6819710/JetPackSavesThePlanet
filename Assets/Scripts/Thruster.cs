using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {
    // Refence Variables
    private Oxygen oxygenSupply;
	private SwipeToMove playerMovement;

    // Settings
    public int depletionAmountPerSecond; // How much Oxygen gets consumed per second

    // Misc
	private Transform jetpack;

    // Use this for initialization
    void Start()
    {
        oxygenSupply = this.gameObject.GetComponent<Oxygen>();
		playerMovement = this.gameObject.GetComponent<SwipeToMove>();
		jetpack = transform.Find ("jetpack");
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygenSupply != null && playerMovement != null)
        {
			if (playerMovement.isMoving) {
				jetpack.gameObject.GetComponent<ParticleSystem> ().Play ();
                float depletionAmount = depletionAmountPerSecond * Time.deltaTime;
                oxygenSupply.ApplyDelta(-depletionAmount);
			} else {
				jetpack.gameObject.GetComponent<ParticleSystem> ().Stop ();
			}
        }
    }
}
