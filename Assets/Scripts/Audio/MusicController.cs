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

    public void toCalm()
    {
        calm.TransitionTo(transition);
    }

    public void toCalmBeat()
    {
        calmBeat.TransitionTo(transition);
    }

    public void toStress()
    {
        stress.TransitionTo(transition);
    }

    public void toStressBeat()
    {
        stressBeat.TransitionTo(transition);
    }

    public void toSilence()
    {
        silence.TransitionTo(transition);
    }

    public void toPanic()
    {
        panic.TransitionTo(transition);
    }

    public void toPanicBeat()
    {
        panicBeat.TransitionTo(transition);
    }

    public void toMenu()
    {
        menu.TransitionTo(transition);
    }
}
