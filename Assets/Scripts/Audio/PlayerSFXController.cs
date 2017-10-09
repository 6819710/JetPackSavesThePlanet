using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSFXController : SoundEffectsController {

	public List<AudioSource> oxygenSounds;

	public List<AudioSource> hurtSounds;
	public List<AudioSource> VocalSounds;
	public List<AudioSource> DeadSounds;

	public bool randomPitched;

	public void Play(SoundEffect toPlay){
		AudioSource audio = null;
		switch(toPlay){
		case SoundEffect.Oxygen:
			audio = RandomFrom (oxygenSounds);
			audio.PlayOneShot (audio.clip);
			break;
		}

	}

	public enum SoundEffect { 
		Oxygen, Hurt, Vocal, Dead
	}


}
