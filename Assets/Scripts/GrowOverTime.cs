using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WormHead))]
public class GrowOverTime : MonoBehaviour {

	public float rateOfGrowth= 10;
	public int lengthGrowth = 1;
	public float widthGrowth = 1.05f;

	public float maxSize = 1.5f;
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
			GrowLength ();
			GrowWidth ();
		}
	}

	private void GrowWidth(){
		if (this.gameObject.transform.localScale.magnitude < new Vector3(rateOfGrowth,rateOfGrowth,rateOfGrowth).magnitude) {
			this.gameObject.transform.localScale *= widthGrowth;
			WormSegment current = this.GetComponent<WormHead> ().Behind;
			while (current.Behind != null) {
				current.Behind.gameObject.transform.localScale *= widthGrowth;
				current = current.Behind;
			}
		}
	}

	private void GrowLength(){
		WormSegment current = this.GetComponent<WormHead> ().Behind;
		while(current.Behind!=null) current = current.Behind;
		current.ExtendWorm(1, 2);
	}
}
