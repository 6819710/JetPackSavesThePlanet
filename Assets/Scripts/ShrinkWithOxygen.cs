using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkWithOxygen : MonoBehaviour {

	private Vector3 initialScale;
	private Oxygen self;

	public bool destoryWhenOut = true;

	// Use this for initialization
	void Start () {
		initialScale = this.gameObject.transform.localScale;
		self = this.gameObject.GetComponent<Oxygen> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (self != null)
			this.gameObject.transform.localScale = initialScale * ((float)self.oxygen / (float)self.maxOxygen) ;
		if (destoryWhenOut) {
			if (self.isOut)
				Destroy (this.gameObject);
		}
	}
}
