using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(WormHead))]
public class StuntingBehavior : MonoBehaviour {

	public float stuntedTime = 3f; //time in seconds to be stunted

	private ParticleSystem ps; 
	private WormHead wh;

	private bool isStunted = false;
	private float initialSpeed;
	private float time;

	void Start () {
		ps = this.gameObject.GetComponent<ParticleSystem> ();
		wh = this.gameObject.GetComponent<WormHead> ();
		ps.Stop ();
		time = stuntedTime;
		initialSpeed = wh.speed;
	}
	
	void Update () {
		if (isStunted) {
			time -= Time.deltaTime;
			if (time < 0) {
				Restore ();
			}
		}
	}

	public void Stunt(){
		isStunted = true;
		ps.Play ();
		wh.speed = 0;
	}

	public void Restore(){
		time = stuntedTime;
		wh.speed = initialSpeed;
		isStunted = false;
		ps.Stop ();
	}
}
