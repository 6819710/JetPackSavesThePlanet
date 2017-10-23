using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrateSoundController : SoundEffectsController {

	public List<AudioSource> spawnSounds;
	public List<AudioSource> collectSounds;
	public List<AudioSource> pingSounds;

	public void Play(SoundEffect toPlay){
		switch(toPlay){
			case SoundEffect.Collect:
				RandomFrom(collectSounds).Play();
				break;
			case SoundEffect.Ping:
				RandomFrom(pingSounds).Play();
				break;
		case SoundEffect.Spawn:
				RandomFrom (spawnSounds).Play ();
				break;
		}

	}
	public void Collect(){
		Play (SoundEffect.Collect);
	}

	public void Ping(){
		Play (SoundEffect.Ping);
	}

	public enum SoundEffect { 
		Collect, Ping, Spawn
	}

}
