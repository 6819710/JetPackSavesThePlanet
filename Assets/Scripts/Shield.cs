using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject owner;
	public List<string> canDestroy;

	private SoundEffectsController sfx;

	public GameObject Owner {
		get {
			return owner;
		}
		set{ owner = value; }
	}

	void Start(){
		sfx = gameObject.GetComponentInChildren<SoundEffectsController> ();
	}

	void Update(){
		if(owner){
			this.transform.position = owner.transform.position;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		sfx.PlayOnce ();
		if(canDestroy.Contains(other.gameObject.tag)){
			if(other.gameObject.GetComponent<Asteroid>()){
				other.gameObject.GetComponent<Asteroid> ().Split (other.contacts[0].normal);
				other.gameObject.GetComponent<Asteroid> ().TakeDamage(1000);
				other.gameObject.GetComponent<Asteroid> ().Destruct ();
			}
		}
	}

	void DestroyShield () {
		Destroy (this.gameObject);
	}
}
