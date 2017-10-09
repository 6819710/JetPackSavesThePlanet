using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterPlayed : MonoBehaviour {

	public AudioSource mySource = null;

	void Start(){
		mySource = GetComponent<AudioSource> ();
	}

    // Update is called once per frame
    void Update () {
		if(mySource && !mySource.isPlaying){
			Destroy (this.gameObject);
		}
	}
}
