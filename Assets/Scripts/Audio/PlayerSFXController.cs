using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSFXController : SoundEffectsController {

	public List<AudioClip> oxygenSounds;

	public List<AudioClip> hurtSounds;
	public List<AudioClip> VocalSounds;
	public List<AudioClip> DeadSounds;

	public bool randomPitched;

	public void Play(SoundEffect toPlay){
		AudioClip audio = null;
		switch(toPlay){
			case SoundEffect.Oxygen:
				audio = RandomFrom(oxygenSounds);
				base.Play(audio);
				break;
		}

	}

	public enum SoundEffect { 
		Oxygen, Hurt, Vocal, Dead
	}


}
