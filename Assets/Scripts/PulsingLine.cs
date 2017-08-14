using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PulsingLine : MonoBehaviour {

	public float pulseDelay = 1; // time in seconds delayed before each pulse
	public float maxRadius = 10; // max distance the pulse will be reached
	public float pulseSpeed = 1; // speed at which the pulse will be traveling

	private float radius;
	private LineRenderer lineRenderer;
	private float time;

	// Use this for initialization
	void Start () {
		time = pulseDelay;
		radius = 0;
		lineRenderer = this.gameObject.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		lineRenderer.enabled = false;
		if (time < 0) {
			lineRenderer.enabled = true;
			radius+= pulseSpeed;
			if (radius > maxRadius) {
				lineRenderer.enabled = false;
				radius = 0;
				time = pulseDelay;
			}
			RedrawCircle (radius);
		}

	}

	void RedrawCircle(float radius){
		lineRenderer.SetPositions(new Vector3[360]);
		lineRenderer.positionCount = 360;
		for (int i = 0; i < lineRenderer.positionCount; i++) {
			float x = radius * Mathf.Cos((i * Mathf.PI)/180) + this.transform.position.x;
			float y = radius * Mathf.Sin((i * Mathf.PI)/180) + this.transform.position.y;
			lineRenderer.SetPosition (i,new Vector3(x,y,1f));
		}
	}
}
