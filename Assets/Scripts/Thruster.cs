using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {
    // Refence Variables
    private Oxygen oxygenSupply;
	private SwipeToMove playerMovement;

    // Settings
    public float depletionRate; // How many seconds need to pass between each use of oxygen
    public int depletionAmount; // How many oxygen gets used with each timer

    // Misc
    private float timer;
	private Transform jetpack;

    // Use this for initialization
    void Start()
    {
        oxygenSupply = this.gameObject.GetComponent<Oxygen>();
		playerMovement = this.gameObject.GetComponent<SwipeToMove>();
		jetpack = transform.Find ("jetpack");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygenSupply != null)
        {
            if(playerMovement != null)
            {
				if (playerMovement.isMoving) {
					jetpack.gameObject.GetComponent<ParticleSystem> ().Play ();
					if (timer >= depletionRate) {
						oxygenSupply.ApplyDelta (-depletionAmount);
						timer = 0;
					} else
						timer += Time.deltaTime;
				} else {
					jetpack.gameObject.GetComponent<ParticleSystem> ().Stop ();
				}
            }
        }
    }
}
