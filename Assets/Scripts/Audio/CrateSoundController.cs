using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrateSoundController : SoundEffectsController {

	public List<AudioClip> spawnSounds;
	public List<AudioClip> collectSounds;
	public List<AudioClip> pingSounds;

	public void Play(SoundEffect toPlay){
		switch(toPlay){
			case SoundEffect.Collect:
				base.Play(RandomFrom(collectSounds));
			break;
			case SoundEffect.Ping:
				base.Play(RandomFrom(pingSounds));
				break;
			case SoundEffect.Spawn:
				base.Play(RandomFrom(spawnSounds));
				break;
		}

	}

	public enum SoundEffect { 
		Collect, Ping, Spawn
	}
}
