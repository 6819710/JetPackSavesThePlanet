using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeToMove : MonoBehaviour {
	
	public float speed = 10;
	public bool flipToDirection = false;
	public GameObject directionalIndicator;
	public float indicatorThreshold = 1.0f;

	private Vector2 originalScale;

    private Vector2 lastMousePosition;
    private bool mouseMoveInProgress = false;

    private Vector2 startSwipePoint;
    private bool swipeInProgress = false;
    public float minSwipeDistance;

    public bool isMoving
	{
		get { 
			return (this.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > indicatorThreshold); 
		}
	}

	// Use this for initialization
	void Start () {
		originalScale = this.gameObject.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
        if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null) {
            if (!Input.mousePresent) {
                TouchMove();
            }
            else {
                MouseMove();
            }
        }
        UpdateDirectionIndicator();
    }

    private void DeltaMouseMove() {
        if (Input.GetMouseButton(0)) {
            lastMousePosition = Input.mousePosition;
            // Get a normalised touch input vector
            Vector2 mouseDirection = ((Vector2)Input.mousePosition - lastMousePosition).normalized;
            Move(mouseDirection);
            lastMousePosition = Input.mousePosition;
        }
    }

    private void MouseMove() {
        if (Input.GetMouseButton(0)) {
            Vector2 mouseDirection = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)) - transform.position).normalized;
            Move(mouseDirection);
        }
    }

    private void TouchMove() {
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                swipeInProgress = true;
                startSwipePoint = Input.GetTouch(0).position;
            }
            Vector2 touchDirection = (Input.GetTouch(0).position - startSwipePoint);
            if (touchDirection.magnitude > minSwipeDistance && swipeInProgress) {
                Move(touchDirection.normalized);
            };
            
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                swipeInProgress = false;
            }
        }
        
    }

    private void Move(Vector2 direction) {
        // If flipToDirection is enable, flip the localscale of the player to match direction 
        if (flipToDirection) {
            Vector2 scale = originalScale;
            if (direction.x < 0)
                scale.x *= -1;
            this.transform.localScale = scale;
        }
        // multiply the touch vector with a speed vector 
        direction *= (speed * 100);

        // Force based movement
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime);
    }

    private void UpdateDirectionIndicator() {
        // If the indicator is available enable it's rendering
        // some math magic to get the indicator to point at the direction where the player is moving 
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > indicatorThreshold) {
            directionalIndicator.GetComponent<SpriteRenderer>().enabled = true;
            float angle = Mathf.Atan2(this.gameObject.GetComponent<Rigidbody2D>().velocity.x, -this.gameObject.GetComponent<Rigidbody2D>().velocity.y) * Mathf.Rad2Deg;
            directionalIndicator.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else {
            // disable it's rendering
            if (directionalIndicator != null)
                directionalIndicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
