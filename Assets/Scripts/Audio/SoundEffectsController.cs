using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsController : MonoBehaviour {

	public List<AudioSource> defaultSources;

	public List<AudioSource> Sources {
		get {
			return defaultSources;
		}
		set {
			defaultSources = value;
		}
	}

	void Start () {
		foreach(AudioSource au in GetComponents<AudioSource> ()){
			defaultSources.Add (au);
		}
	}

	public virtual void Play(){
		RandomFrom(defaultSources).Play();
	}

	public static AudioSource RandomFrom(List<AudioSource> toSelect){
		return toSelect[Random.Range(0,toSelect.Count)];
	}



}
