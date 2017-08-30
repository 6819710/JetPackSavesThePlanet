﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownianMotion : MonoBehaviour {

	// Use this for initialization
	public float amplitude = 10;
    public bool ignoreMass = true;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 randomVector = new Vector2 (Random.Range(-amplitude,amplitude),Random.Range(-amplitude,amplitude));
		float randomTorque = Random.Range(-amplitude/10,amplitude/10);

        if (ignoreMass) {
            randomVector *= GetComponent<Rigidbody2D>().mass;
            randomTorque *= GetComponent<Rigidbody2D>().mass;
        }
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (randomVector);
		this.gameObject.GetComponent<Rigidbody2D> ().AddTorque (randomTorque);
	}
}
