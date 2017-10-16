using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    public float forceStrength = 100f;
    public float minSwipeDistance;
    public float maxSwipeAngle = 180f;
    public MovementType moveType = MovementType.SwipeJoystick;

    public Vector2 swipeAngleReference = Vector2.up;
    public Vector3 movementScaling = Vector3.one;
    public Rigidbody2D rbToMove;
    public GameObject directionalIndicator;

    public bool isAllowedToMove = true;

    protected bool stopped = false;
    protected Vector2 startSwipePoint;
    protected Vector2 currentSwipePoint;

    protected bool swipeInProgress = false;
    protected bool currentSwipeValid = false;

    private bool sfxReset = false; //holds state of sfx flag
    private GameObject sfxController;

	private Vector3 initialIndicatorScale;
	public float maxIndicatorStretch = 3f;

    public bool isMoving
	{
        get
        {
            return (this.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude > 0); 
        }
    }

	// Use this for initialization
	void Start () {
        if (!rbToMove) rbToMove = GetComponent<Rigidbody2D>();
        sfxController = GameObject.Find("SFX");
		initialIndicatorScale = directionalIndicator.transform.localScale;
    }

    void FixedUpdate() {
		//IsPointerOverGameObject = !EventSystem.current.IsPointerOverGameObject ();
		//currentSelectedGameObject = (EventSystem.current.currentSelectedGameObject == null);
        if (isAllowedToMove) {
			/* @Gavin: I removed the additional if statement here that caused miss register of the first input
			 * Wasn't sure if they were required, but removal does seem to solve the issue
			 * 
			 * REMOVED: IsPointerOverGameObject && currentSelectedGameObject
			 */
			if (moveType != MovementType.Analog)
           		MouseMove();
			else
				AnalogMove();
        }
        UpdateDirectionIndicator();
    }

	private void AnalogMove(){
		startSwipePoint =  Vector3.zero;
		currentSwipePoint = new Vector3( Input.GetAxis ("Horizontal"),  Input.GetAxis ("Vertical"), 0);
		swipeInProgress = (currentSwipePoint.magnitude > Vector3.zero.magnitude);
		Move(rbToMove, GetMoveDirection(), forceStrength);
		UpdateDirectionIndicator ();
	}

    protected void MouseMove() {
        if (Input.GetMouseButtonDown(0)) {
            StartSwipe(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) {
            UpdateSwipe(Input.mousePosition);
        }
        else {
            FinishSwipe();
        }
    }
    
    protected void StartSwipe(Vector2 startInputScreenPos) {
        swipeInProgress = true;
        currentSwipeValid = false;
        startSwipePoint = startInputScreenPos;
        currentSwipePoint = startSwipePoint;
    }

    protected void UpdateSwipe(Vector2 newInputScreenPos) {
        if (!swipeInProgress) return;
        currentSwipePoint = newInputScreenPos;
        if (SwipeValid()) {
            Move(rbToMove, GetMoveDirection(), forceStrength);
        }
    }

    protected void FinishSwipe() {
        if (!swipeInProgress) return;
        ResetSwipeState();
    }

    protected void ResetSwipeState() {
        swipeInProgress = false;
        currentSwipeValid = false;
        startSwipePoint = Vector2.zero;
        currentSwipePoint = Vector2.zero;
    }

    protected bool SwipeValid() {
        var swipeDistance = Vector2.Distance(startSwipePoint, currentSwipePoint);
        var angle = Vector2.Angle(GetMoveDirection(), swipeAngleReference);
        if (swipeDistance > minSwipeDistance && angle < maxSwipeAngle) currentSwipeValid = true;
        else currentSwipeValid = false;

        return currentSwipeValid;
    }

    protected void Move(Rigidbody2D rb, Vector2 dir, float forceStrength) {
        rb.AddForce(dir * forceStrength, ForceMode2D.Impulse);
        stopped = false;
        SFX();
    }
    
    public void StopMovement() {
        rbToMove.velocity = Vector2.zero;
        stopped = true;
    }

    public bool IsValidSwipeInProgress() {
        return swipeInProgress && currentSwipeValid;
    }

    public Vector2 GetMoveDirection() {
        Vector2 moveDirection = Vector2.zero;
        switch (moveType) {
            case MovementType.SwipeJoystick:
                moveDirection = (Camera.main.ScreenToWorldPoint(currentSwipePoint) - Camera.main.ScreenToWorldPoint(startSwipePoint)).normalized;
                break;
            case MovementType.ToPoint:
                moveDirection = (Camera.main.ScreenToWorldPoint(currentSwipePoint) - rbToMove.transform.position).normalized;
                break;
			case MovementType.Analog:
				moveDirection = new Vector3( Input.GetAxis ("Horizontal"),  Input.GetAxis ("Vertical"), 0);
				break;
            default: break;
        }
        Vector2 scaledMoveDir = Vector2.Scale(moveDirection, movementScaling).normalized;
        return scaledMoveDir;
    }

    private void UpdateDirectionIndicator() {
        //If the indicator is available enable it's rendering
        // some math magic to get the indicator to point at the direction where the player is moving
        if (swipeInProgress) {
            directionalIndicator.GetComponent<SpriteRenderer>().enabled = true;
            float angle = Mathf.Atan2(GetMoveDirection().x, -GetMoveDirection().y) * Mathf.Rad2Deg;
            directionalIndicator.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			float strech = Mathf.Min( (initialIndicatorScale.x) * maxIndicatorStretch ,Mathf.Max ( (initialIndicatorScale.x) * (startSwipePoint-currentSwipePoint).magnitude / (Screen.width/3) ,  (initialIndicatorScale.x))) ;
			directionalIndicator.transform.localScale =  new Vector3(strech, initialIndicatorScale.y,initialIndicatorScale.z );
        }
        else {
            // disable it's rendering
            if (directionalIndicator != null)
                directionalIndicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void SFX()
    {
        if (!sfxReset)
        {
            sfxController.SendMessage("playJetpack");
            sfxReset = true; // Set flag once sfx triggered
        }
        else if (!isMoving)
            sfxReset = false;
    }

    public enum MovementType {
        SwipeJoystick,
        ToPoint,
		Analog
    }
}
