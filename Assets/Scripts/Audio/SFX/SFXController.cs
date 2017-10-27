using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Class for SFX Controllers
/// Allows for List Based SFX Control
/// </summary>
public class SFXController : MonoBehaviour {

    //Controller Settings
    public List<AudioSource> _sfx;

    public bool _destroyOnPlay;

    //Destruction Tools
    private bool _trigger = false;
    private int _triggerSource;

    /// <summary>
    /// Runs on Object Update
    /// Used for Destroy On Playing of SFX
    /// </summary>
    private void Update()
    {
        if (_trigger && !_sfx[_triggerSource].isPlaying)
            Destroy(this.gameObject);
    }

    /// <summary>
    /// Will attempt to play a random SFX that is not currently playing.
    /// Will run n attempts, where n is the number of SFX Sources avalible in _sfx.
    /// When attempts are not suscussfull will play first SFX that is not currently playing.
    /// </summary>
    public void playRandom()
    {
        for (int i = 0; i < _sfx.Count; i++) // Run n attempts.
        {
            int play = Random.Range(0, _sfx.Count);
            if (!_sfx[i].isPlaying)
            {
                _sfx[i].Play();
                if (_destroyOnPlay)
                {
                    _trigger = true;
                    _triggerSource = i;
                }
                return;
            }
        }

        for (int i = 0; i < _sfx.Count; i++) // Play first avalible.
        {
            if (!_sfx[i].isPlaying)
            {
                _sfx[i].Play();
                if (_destroyOnPlay)
                {
                    _trigger = true;
                    _triggerSource = i;
                }
                return;
            }
        }
            
    }

    /// <summary>
    /// Plays a given SFX
    /// </summary>
    /// <param name="i">Position of SFX in list.</param>
    public void playSource(int i)
    {
        if (_destroyOnPlay)
        {
            _trigger = true;
            _triggerSource = i;
        }
        if (!_sfx[i].isPlaying)
            _sfx[i].Play();
    }
}
