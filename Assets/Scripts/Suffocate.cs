using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Oxygen))]
[RequireComponent(typeof(Health))]
public class Suffocate : MonoBehaviour {

	public float damage = 10f;	 // amount of suffocation damage	
	public float delay = 1f;	 // delay of suffocation damage	
	public float frequency = 1f; // frequency of suffocation damage

	private Oxygen oxygen;
	private Health health;
	private float time;

	public bool isSuffocating{
		get { return (oxygen != null && oxygen.isOut); };
	}

	// Use this for initialization
	void Start () {
		oxygen = gameObject.GetComponent<Oxygen> ();
		health = gameObject.GetComponent<Health> ();
		time = frequency + delay;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (isSuffocating) {
			if (time < 0) {
				health.dealDamage (damage);
				time = frequency;
			}
		} else {
			time = frequency + delay;
		}
	}
}
