using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {

	private Text diplay;
	// Use this for initialization
	void Start () {
		diplay = GetComponent<Text> ();
	}

	public void Update()
	{
		diplay.text = string.Format("{0:0.00} FPS",Time.frameCount / Time.time );
	}
}
