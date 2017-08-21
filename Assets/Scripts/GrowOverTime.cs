using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WormHead))]
public class GrowOverTime : MonoBehaviour {

	public float rateOfGrowth= 10;
	public int amountOfGrowth = 1;
	// Use this for initialization

	private float time; 

	void Start () {
		time = rateOfGrowth;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			time = rateOfGrowth;
			Grow ();
		}
	}

	private void Grow(){
		WormSegment current = this.GetComponent<WormHead> ().Behind;
		while(current.Behind!=null) current = current.Behind;
		current.ExtendWorm(1, 2);
	}
}
