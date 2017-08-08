using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToMove : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public float smoothTime = 1f;
	public bool flipToDirection = true;

	private Vector3 target;

	private Vector3 initialScale;

	public bool isMoving
	{
		get { 
			return !target.Equals (transform.position);
		}
	}

	void Start () {
		initialScale = this.transform.localScale;
	}

	void Update () {
		if (Input.GetMouseButton (0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = this.transform.position.z;
			if (flipToDirection) {
				Vector3 newScale = initialScale;
				newScale.x = (target.x > this.transform.position.x) ? initialScale.x : -initialScale.x;
				this.transform.localScale = newScale;
			}
		}
		if (!transform.position.Equals (target)) {
			Vector2 velocity = Vector2.zero;
			transform.position = Vector2.SmoothDamp(transform.position, Vector2.MoveTowards(transform.position,target, maxSpeed), ref velocity, smoothTime, maxSpeed, 1f);
		}

	}
}
