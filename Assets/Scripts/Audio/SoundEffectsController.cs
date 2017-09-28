using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsController : MonoBehaviour {
	
	private AudioSource source;

	private List<AudioClip> defaultClips;

	public AudioSource Source {
		get {
			return source;
		}
		set {
			source = value;
		}
	}

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	public void Play(){
		Source.PlayOneShot (RandomFrom(defaultClips));
	}

	public void Play(AudioClip toPlay){
		Source.PlayOneShot (toPlay);
	}

	public void Play(AudioClip toPlay, float min, float max){
		float randomVolume = Random.Range (min,max);
		Source.PlayOneShot (toPlay,randomVolume);
	}

	public static AudioClip RandomFrom(List<AudioClip> toSelect){
		return toSelect[Random.Range(0,toSelect.Count)];
	}



}
