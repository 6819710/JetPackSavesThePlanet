using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlayed : MonoBehaviour {

	private AudioSource mySource;

	void Start () {
		mySource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!mySource.isPlaying){
			Destroy (this.gameObject);
		}
	}
}
