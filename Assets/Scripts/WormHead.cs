using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIBehaviourStateController))]
public class WormHead : WormSegment {

    public int startSize = 1;
    public Transform mainTarget;
    public bool isDebug;
    public float speed;
    public float catchUpExponent =1f;
    public float maxSpeed = 100;

    public float attackAmount = 1;
    public float retreatTime = 1;
    private AIBehaviourStateController AIbsc;
    private Vector2 retreatOffset;
    private Vector2 retreatTo;

    void Start() {
        AIbsc = gameObject.GetComponent<AIBehaviourStateController>();
        AIbsc.ChangeState(AIBehaviourState.following);
        if (startSize < 1) startSize = 1;
        ExtendWorm(1, startSize);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        Debug.Log(AIbsc.GetCurrentState());
        switch (AIbsc.GetCurrentState()){
            case AIBehaviourState.debug: {
                    MoveWormHead(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)), catchUpExponent);
                }
                break;
            case AIBehaviourState.idle: break;
            case AIBehaviourState.following: {
                    MoveWormHead(mainTarget.position, catchUpExponent);
                }
                break;
            case AIBehaviourState.retreating: {
                    MoveWormHead(retreatTo);
                }
                break;
            default: break;
        }
        MoveWorm();
    }

    private void MoveWormHead(Vector2 targetPos, float catchUpExponent = 0) {
        Vector2 direction = targetPos - (Vector2)transform.position;
        var modifiedSpeed = Mathf.Min(Mathf.Max(1, speed * Mathf.Pow(direction.magnitude, catchUpExponent), maxSpeed));
        direction = direction.normalized * modifiedSpeed;
        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + ( direction * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") { //TODO Gavin: remove hardcoded tag
			Health health = collision.gameObject.GetComponent<Health>();
			if(health !=null){
				health.dealDamage (attackAmount);
			}
        }
		if (collision.gameObject.layer == LayerMask.NameToLayer("Astroid")) { //TODO Isuru: remove hardcoded tag
            //If wworm on screen then retreat when hittinng asteroids
            var screenCenterWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.transform.position.z));
            var screenBottomCenterWorldCoordinates = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, Camera.main.transform.position.z));
            if ( Vector3.Distance(mainTarget.position, transform.position) < Vector3.Distance(screenCenterWorldCoordinates, screenBottomCenterWorldCoordinates)) {
                AIbsc.ChangeState(AIBehaviourState.retreating, retreatTime);
                var normal = collision.contacts[0].normal;
                var distance = collision.contacts[0].relativeVelocity.magnitude;
                retreatTo = distance * normal + collision.contacts[0].point;
            }
        }
    }
}
