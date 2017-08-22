using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHead : WormSegment {

    public int startSize = 1;
    public Transform mainTarget;
    public bool isDebug;
    public float speed;

    void Start() {
        if (startSize < 1) startSize = 1;
        ExtendWorm(1, startSize);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        if (isDebug)
            MoveWormHead(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)));
        else MoveWormHead(mainTarget.position);
        MoveWorm();
    }

    private void MoveWormHead(Vector2 targetPos) {
        Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + (speed * Time.deltaTime * direction));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") { //TODO Gavin: remove hardcoded tag
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckIfLoss>().TriggerLoss();
        }
    }
}
