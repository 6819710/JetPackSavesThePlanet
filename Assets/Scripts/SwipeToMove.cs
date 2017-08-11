using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToMove : MonoBehaviour {
	
	public float speed = 100;
	public bool flipToDirection = false;
	public GameObject directionalIndicator;
	public float indicatorThreshold = 1.0f;

	private Vector2 originalScale;

	public bool isMoving
	{
		get { 
			return (this.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > indicatorThreshold); 
		}
	}

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		originalScale = this.gameObject.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			// Get a normalised touch input vector
			Vector2 touchDirection = Input.GetTouch (0).deltaPosition.normalized;
			// If flipToDirection is enable, flip the localscale of the player to match direction 
			if (flipToDirection) {
				Vector2 scale = originalScale;
				if (touchDirection.x < 0)
					scale.x *= -1;
				this.transform.localScale = scale;
			}
			// multiply the touch vector with a speed vector 
			touchDirection.Scale (new Vector2 (speed, speed));
			// Force based movement
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (touchDirection);
			// If the indicator is available
			if (directionalIndicator != null) {
				
			}
		} 

		// If the indicator is available enable it's rendering
		// some math magic to get the indicator to point at the direction where the player is moving 
		if (this.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > indicatorThreshold) {
			directionalIndicator.GetComponent<SpriteRenderer> ().enabled = true;
			float angle = Mathf.Atan2 (this.gameObject.GetComponent<Rigidbody2D> ().velocity.x, -this.gameObject.GetComponent<Rigidbody2D> ().velocity.y) * Mathf.Rad2Deg;
			directionalIndicator.transform.rotation = Quaternion.AngleAxis (angle - 90, Vector3.forward);
		} else {
			// disable it's rendering
			if (directionalIndicator != null)
				directionalIndicator.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
