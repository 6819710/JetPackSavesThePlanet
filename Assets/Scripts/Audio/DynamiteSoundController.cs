using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteSoundController : SoundEffectsController {

	public List<AudioSource> fuseSounds;
	public List<AudioSource> ExplodeSounds;

	public void Play(SoundEffect toPlay){
		switch(toPlay){
		case SoundEffect.Fuse:
			RandomFrom(fuseSounds).Play();
			break;
		case SoundEffect.Explode:
			RandomFrom (ExplodeSounds).Play ();
			break;
		}

	}

	public void Fuse(){
		Play (SoundEffect.Fuse);
	}

	public void Explode(){
		Play (SoundEffect.Explode);
	}

	public enum SoundEffect { 
		Fuse, Explode
	}

}
