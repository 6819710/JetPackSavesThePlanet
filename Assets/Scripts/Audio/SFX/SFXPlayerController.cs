using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SFX Controler for Player.
/// </summary>
public class SFXPlayerController : SFXController {
    // Death SFX
    /// <summary>
    /// Plays Death SFX based on the cause of the death event.
    /// </summary>
    /// <param name="causeOfDeath"></param>
    public void PlayDeath(Health.DamageType causeOfDeath)
    {
        switch(causeOfDeath)
        {
            case Health.DamageType.Suffocation:
                PlayDeathSuffocation();
                break;
            case Health.DamageType.Worm:
                PlayDeathWorm();
                break;
            case Health.DamageType.Explosion:
                PlayDeathExplosion();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Plays the Death By Suffocation SFX.
    /// </summary>
    public void PlayDeathSuffocation()
    {
        if(!_sfx[0].isPlaying)
            _sfx[0].Play();
    }

    /// <summary>
    /// Plays the Death By Worm SFX.
    /// </summary>
    public void PlayDeathWorm()
    {
        if (!_sfx[1].isPlaying)
            _sfx[1].Play();
    }

    /// <summary>
    /// Plays the Death By Explosion SFX.
    /// </summary>
    public void PlayDeathExplosion()
    {
        if (!_sfx[2].isPlaying)
            _sfx[2].Play();
    }

    // Jetpack SFX
}
