using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToMove : MonoBehaviour {
	
	public float speed = 100;
	public bool changeDirection = false;
	public GameObject directionalIndicator;

	private Vector2 originalScale;

	public bool isMoving
	{
		get { 
			return (this.gameObject.GetComponent<Rigidbody2D> ().velocity != Vector2.zero); 
		}
	}

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		originalScale = this.gameObject.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		Transform jetpack = transform.Find ("jetpack");
		if(directionalIndicator!=null) directionalIndicator.GetComponent<SpriteRenderer> ().enabled = false;
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			jetpack.gameObject.GetComponent<ParticleSystem> ().Play ();
			Vector2 touchDirection = Input.GetTouch (0).deltaPosition.normalized;
			if (changeDirection) {
				Vector2 scale = originalScale;
				if (touchDirection.x < 0)
					scale.x *= -1;
				this.transform.localScale = scale;
			}
			touchDirection.Scale (new Vector2 (speed, speed));
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (touchDirection);
			if (directionalIndicator != null) {
				directionalIndicator.GetComponent<SpriteRenderer> ().enabled = true;
				float angle = Mathf.Atan2 (this.gameObject.GetComponent<Rigidbody2D> ().velocity.x, -this.gameObject.GetComponent<Rigidbody2D> ().velocity.y) * Mathf.Rad2Deg;
				directionalIndicator.transform.rotation = Quaternion.AngleAxis (angle - 90, Vector3.forward);
			}
		} else {
			jetpack.gameObject.GetComponent<ParticleSystem> ().Stop ();
		}
	}
}
