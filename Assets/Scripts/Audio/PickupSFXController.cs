using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSFXController : MonoBehaviour {

    public AudioSource coinPickup;
    public AudioSource crateSpawn;
    public AudioSource crateCollect;
    public AudioSource cratePing;

    public void PlayCoinPickup()
    {
        if (!coinPickup.isPlaying)
            coinPickup.Play();
    }

    public void PlayCrateSpawn()
    {
        if (!crateSpawn.isPlaying)
            crateSpawn.Play();
    }

    public void PlayCrateCollect()
    {
        gameObject.GetComponent<DestroyAfterPlayed>().mySource = crateCollect;
        if (!crateCollect.isPlaying)
            crateCollect.Play();
    }

    public void PlayCratePing()
    {
            cratePing.Play();
    }
}
