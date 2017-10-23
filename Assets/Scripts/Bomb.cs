using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class Bomb : MonoBehaviour {

	public float fuseTime = 3f;
	public float damageRadius = 1f;
	public float damageAmount = 5f;

	private float time;

	private bool exploded = false;

	public UnityEvent onExplode;

	void Start () {
		time = fuseTime;
		gameObject.GetComponent<ParticleSystem> ().Play (false);
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0 && !exploded) {
			exploded = true;
			Explode ();
		}
		if (gameObject.GetComponent<ParticleSystem> ().isStopped) {
			Destroy (this.gameObject,2f);
		}

	}

	void Explode(){
		foreach (Collider2D hitColliders in Physics2D.OverlapCircleAll(transform.position,damageRadius)) {
			if(hitColliders.gameObject.GetComponent<WormSegment>()){
				hitColliders.gameObject.GetComponent<WormSegment> ().dealDamage (damageAmount);
			}
			if(hitColliders.gameObject.GetComponent<Health>()){
				hitColliders.gameObject.GetComponent<Health> ().dealDamage (Health.DamageType.Explosion,100);
			}
			if(hitColliders.gameObject.GetComponent<Asteroid>()){
				hitColliders.gameObject.GetComponent<Asteroid>().Split (hitColliders.gameObject.transform.position - this.transform.position);
				hitColliders.gameObject.GetComponent<DestructableEntity>().Destruct ();
			}
		}
		onExplode.Invoke ();
	}
}
