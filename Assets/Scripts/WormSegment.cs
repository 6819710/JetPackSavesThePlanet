using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class WormSegment : MonoBehaviour {

    public bool isHead = false;
    public int startSize = 1;
    public WormSegment wormSegmentPrefab;
    private WormSegment attachedTo;

    // Use this for initialization
    void Start () {
        if (isHead) {
            if (startSize < 1) startSize = 1;
            ExtendWorm(startSize);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (attachedTo) {
            Vector3 targetPos = attachedTo.transform.position;
            transform.position = targetPos + (transform.position - targetPos).normalized * (GetComponent<CircleCollider2D>().radius + attachedTo.GetComponent<CircleCollider2D>().radius);
        }
    }

    public void ExtendWorm(int n) {
        if (n < 1) return;
        var newSegment = Instantiate(wormSegmentPrefab, transform.parent);
        newSegment.AttachTo(this);
        if (!attachedTo) newSegment.transform.localPosition = 2 * GetComponent<CircleCollider2D>().radius * (transform.position - Vector3.up).normalized;
        else newSegment.transform.localPosition = (GetComponent<CircleCollider2D>().radius + attachedTo.GetComponent<CircleCollider2D>().radius) * (transform.position - attachedTo.transform.position).normalized;
        newSegment.ExtendWorm(n - 1);
    }

    public void AttachTo(WormSegment segment) {
        attachedTo = segment;
    }
}
