using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrateSoundController : SoundEffectsController {
    PickupSFXController SFX;

    private void Start()
    {
        SFX = this.gameObject.GetComponentInChildren<PickupSFXController>();
    }

    public void Collect(){
		SFX.PlayCrateCollect();
	}

	public void Ping(){
        SFX.PlayCratePing();
	}

    public void Create()
    {
        SFX.PlayCrateSpawn();
    }
}
