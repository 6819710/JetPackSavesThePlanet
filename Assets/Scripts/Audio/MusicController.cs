using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {

    public AudioMixerSnapshot calm;
    public AudioMixerSnapshot calmBeat;
    public AudioMixerSnapshot stress;
    public AudioMixerSnapshot stressBeat;
    public AudioMixerSnapshot silence;
    public AudioMixerSnapshot panic;
    public AudioMixerSnapshot panicBeat;
    public AudioMixerSnapshot menu;

    public List<AudioSource> sorces;

    public float bpmNormal = 60.0f;
    public float bpmIncreased = 75.0f;
    public float bpmFast = 90.0f;

    public float bpmBase = 60.0f;

    public float bpm = 60.0f;

    private float transition;
    private float quaterNote;

	// Use this for initialization
	void Start ()
    {
        quaterNote = 60.0f / bpm;
        transition = quaterNote;
        toMenu();
	}

    private void setBPM(float aBPM)
    {
        float pitch = aBPM / bpm; //calculate putch setting from base bpm

        foreach(AudioSource s in sorces)
        {
            s.pitch = pitch;
        }
    }

    public void toCalm()
    {
        calm.TransitionTo(transition);
        setBPM(bpmNormal);
    }

    public void toCalmBeat()
    {
        calmBeat.TransitionTo(transition);
        setBPM(bpmNormal);
    }

    public void toStress()
    {
        stress.TransitionTo(transition);
        setBPM(bpmIncreased);
    }

    public void toStressBeat()
    {
        stressBeat.TransitionTo(transition);
        setBPM(bpmIncreased);
    }

    public void toSilence()
    {
        silence.TransitionTo(transition);
        setBPM(bpmNormal);
    }

    public void toPanic()
    {
        panic.TransitionTo(transition);
        setBPM(bpmFast);
    }

    public void toPanicBeat()
    {
        panicBeat.TransitionTo(transition);
        setBPM(bpmFast);
    }

    public void toMenu()
    {
        menu.TransitionTo(transition);
        setBPM(bpmNormal);
    }
}
