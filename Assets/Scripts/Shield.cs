using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	private ShieldSFXControler sfx;
	public GameObject owner;
	public List<string> canDestroy;

	public GameObject Owner {
		get {
			return owner;
		}
		set{ owner = value; }
	}

	void Start(){
		sfx = gameObject.GetComponentInChildren<ShieldSFXControler> ();
	}

	void Update(){
		if(owner){
			this.transform.position = owner.transform.position;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		sfx.playRandom ();

		if(canDestroy.Contains(other.gameObject.tag)){
			if(other.gameObject.GetComponent<Asteroid>()){
				other.gameObject.GetComponent<Asteroid> ().Split (other.contacts[0].normal);
				other.gameObject.GetComponent<Asteroid> ().TakeDamage(1000);
				other.gameObject.GetComponent<Asteroid> ().Destruct ();
			}
		}
		if (other.gameObject.CompareTag("Worm")) {
			other.gameObject.GetComponentInChildren<WormHead>().Stunt (other);
		}
	}

	void DestroyShield () {
		Destroy (this.gameObject);
	}
}
