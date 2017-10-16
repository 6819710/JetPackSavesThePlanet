using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIBehaviourStateController))]
public class WormHead : WormSegment {

    public int startSize = 1;
    public Transform mainTarget;
    public bool isDebug;
    public float minSpeed;
    public float catchUpExponent = 1f;
    public float minDistanceBeforeCatchUp = 3f;
    public float maxSpeed = 100;
    public float attackAmount = 1;
    public float retreatTime = 1;
    private AIBehaviourStateController AIbsc;
    private Vector2 retreatOffset;
    private Vector2 retreatTo;

	public List<string> canBeStunnedByTagged;

	private ParticleSystem ps;

    void Start() {
        if (!mainTarget) mainTarget = GameObject.FindGameObjectWithTag("Player").transform;
        AIbsc = gameObject.GetComponent<AIBehaviourStateController>();
        AIbsc.ChangeState(AIBehaviourState.following);
        if (startSize < 1) startSize = 1;
        ExtendWorm(1, startSize);
		ps = gameObject.GetComponent<ParticleSystem> ();
    }

	public Transform Target {
		get { return mainTarget; }
	}

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        switch (AIbsc.GetCurrentState()){
            case AIBehaviourState.debug: {
                    MoveWormHead(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)), catchUpExponent);
                }
                break;
            case AIBehaviourState.idle: break;
            case AIBehaviourState.following: {
					ps.Stop ();
                    MoveWormHead(mainTarget.position, catchUpExponent);
                }
                break;
            case AIBehaviourState.retreating: {
					ps.Play ();
                    MoveWormHead(retreatTo);
                }
                break;
            default: break;
        }
        MoveWorm();
    }

	private void MoveWormHead(Vector2 targetPos, float catchUpExponent = 0) {
		Vector2 direction = targetPos - (Vector2)transform.position;
		float catchUpFactor = Mathf.Max(1, Vector3.Distance(targetPos, transform.position) - minDistanceBeforeCatchUp);
		var modifiedSpeed = Mathf.Min(minSpeed * Mathf.Max(1, Mathf.Pow(catchUpFactor, catchUpExponent)), maxSpeed);
		direction = direction.normalized * modifiedSpeed;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + (direction * Time.deltaTime));
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") { //TODO Gavin: remove hardcoded tag
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null) {
				health.dealDamage(Health.DamageType.Worm,attackAmount);
            }
        }
		if (canBeStunnedByTagged.Contains(collision.gameObject.tag) ) {
            //If wworm on screen then retreat when hittinng asteroids
            var screenCenterWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.transform.position.z));
            var screenBottomCenterWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.transform.position.z));
            if (Vector3.Distance(mainTarget.position, transform.position) < Vector3.Distance(screenCenterWorldCoordinates, screenBottomCenterWorldCoordinates)) {
                AIbsc.ChangeState(AIBehaviourState.retreating, retreatTime);
                var normal = collision.contacts[0].normal;
                var distance = collision.contacts[0].relativeVelocity.magnitude;
                retreatTo = distance * normal + collision.contacts[0].point;
            }
        }
    }
}
