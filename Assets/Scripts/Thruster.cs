using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {
	// Refence Variables
	private Rigidbody2D ownerBody;
    private Oxygen oxygenSupply;
	private Movement playerMovement;
	private AudioSource sounds;

    // Settings
    public int depletionAmountPerSecond; // How much Oxygen gets consumed per second

    // Misc
	private Transform jetpack;

    // Use this for initialization
    void Start()
    {
		ownerBody = this.gameObject.GetComponent<Rigidbody2D>();
        oxygenSupply = this.gameObject.GetComponent<Oxygen>();
		playerMovement = this.gameObject.GetComponent<Movement>();
		jetpack = transform.Find ("SFXJetpack");
		sounds = jetpack.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygenSupply != null && playerMovement != null)
        {
			ParticlesEnabled (playerMovement.isBeingMoved);
			if (playerMovement.isBeingMoved) {
				oxygenSupply.ApplyDelta (-depletionAmountPerSecond * Time.deltaTime);
				sounds.volume+=0.1f;
				sounds.pitch = ownerBody.velocity.magnitude / 3.5f;
				if(!sounds.isPlaying) sounds.Play ();
			} else {
				sounds.volume-=0.2f;
				if(sounds.pitch > 1) sounds.pitch-=0.2f;
				sounds.Stop ();
			}
        }
    }

	public void ParticlesEnabled(bool should){
		if(should) jetpack.gameObject.GetComponent<ParticleSystem> ().Play ();
		else jetpack.gameObject.GetComponent<ParticleSystem> ().Stop ();
	}
}
