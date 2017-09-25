using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinSoundEffectController : SoundEffectsController {

	public List<AudioClip> coinCollectSounds;

	public void Play(SoundEffect toPlay){
		AudioClip audio = null;
		switch(toPlay){
			case SoundEffect.Collect:
				audio = RandomFrom(coinCollectSounds);
				base.Play(audio);
			break;
		}

	}

	public enum SoundEffect { 
		Collect, Bounce, Spawn
	}
}
