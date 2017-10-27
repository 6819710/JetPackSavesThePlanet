using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Global Music Controller
/// </summary>
public class MusicController : MonoBehaviour {

    // Audio Mixer Snapshots
    public AudioMixerSnapshot _calm;
    public AudioMixerSnapshot _calmBeat;

    public AudioMixerSnapshot _stress;
    public AudioMixerSnapshot _stressBeat;
    
    public AudioMixerSnapshot _panic;
    public AudioMixerSnapshot _panicBeat;

    public AudioMixerSnapshot _silence;
    public AudioMixerSnapshot _menu;

    public List<AudioSource> _sourceList;

    // BPM Alterations
    public float _bpmNormal = 60.0f;
    public float _bpmIncreased = 75.0f;
    public float _bpmFast = 90.0f;

    private float _bpm = 60.0f;

    // Transistion Settings
    private float _transition;
    private float _quaterNote;

    /// <summary>
    /// Set Quaternote and Base Transisiton time on Start.
    /// </summary>
	void Start ()
    {
        _quaterNote = 60.0f / _bpm;
        _transition = 0.0f;
        toMenu();
	}

    /// <summary>
    /// Sets BPM on all Audio Sorces (Used to keep beats in sync).
    /// </summary>
    /// <param name="aBPM">BPM to change to</param>
    private void setBPM(float aBPM)
    {
        float pitch = aBPM / _bpm; //calculate putch setting from base bpm

        foreach(AudioSource s in _sourceList)
        {
            s.pitch = pitch;
        }
    }

    /// <summary>
    /// Transition Music to Calm Snapshot
    /// </summary>
    public void toCalm()
    {
        _calm.TransitionTo(_transition);
        setBPM(_bpmNormal);
    }

    /// <summary>
    /// Transition Music to Calm Beat Snapshot
    /// </summary>
    public void toCalmBeat()
    {
        _calmBeat.TransitionTo(_transition);
        setBPM(_bpmNormal);
    }

    /// <summary>
    /// Transition Music to Stress Snapshot
    /// </summary>
    public void toStress()
    {
        _stress.TransitionTo(_transition);
        setBPM(_bpmIncreased);
    }

    /// <summary>
    /// Transition Music to Stress Beat Snapshot
    /// </summary>
    public void toStressBeat()
    {
        _stressBeat.TransitionTo(_transition);
        setBPM(_bpmIncreased);
    }

    /// <summary>
    /// Transition Music to Panic Snapshot
    /// </summary>
    public void toPanic()
    {
        _panic.TransitionTo(_transition);
        setBPM(_bpmFast);
    }

    /// <summary>
    /// Transition Music to Panic Beat Snapshot
    /// </summary>
    public void toPanicBeat()
    {
        _panicBeat.TransitionTo(_transition);
        setBPM(_bpmFast);
    }

    /// <summary>
    /// Transition Music to Silence Snapshot
    /// </summary>
    public void toSilence()
    {
        _silence.TransitionTo(_transition);
        setBPM(_bpmNormal);
    }

    /// <summary>
    /// Transition Music to Menu Snapshot
    /// </summary>
    public void toMenu()
    {
        _menu.TransitionTo(_transition);
        setBPM(_bpmNormal);
    }
}
