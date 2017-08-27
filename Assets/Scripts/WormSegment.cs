using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class WormSegment : MonoBehaviour {

    public WormSegment wormSegmentPrefab;
    private WormSegment segmentAhead;
    private WormSegment segmentBehind;

	public WormSegment Ahead {
		get { return segmentAhead; }
		set { segmentAhead = value; } 
	}

	public WormSegment Behind {
		get { return segmentBehind; }
		set { segmentBehind = value; } 
	}

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {
    }

    private void MoveWormSegment() {
        Vector3 targetPos = segmentAhead.transform.position;
        transform.position = targetPos + (transform.position - targetPos).normalized * (GetComponent<CircleCollider2D>().radius + segmentAhead.GetComponent<CircleCollider2D>().radius);
    }

    public void ExtendWorm(int currentSize, int maxSize) {
        if (currentSize >= maxSize) return;
        var newSegment = Instantiate(wormSegmentPrefab, transform.parent);
        newSegment.name = "worm-segment-" + currentSize;
        newSegment.SetSegmentAhead(this);
        segmentBehind = newSegment;
        if (!segmentAhead) newSegment.transform.localPosition = 2 * GetComponent<CircleCollider2D>().radius * (transform.position - Vector3.up).normalized;
        else newSegment.transform.localPosition = (GetComponent<CircleCollider2D>().radius + segmentAhead.GetComponent<CircleCollider2D>().radius) * (transform.position - segmentAhead.transform.position).normalized;
        newSegment.ExtendWorm(currentSize + 1, maxSize);
    }

    public void MoveWorm() {
        if (segmentBehind) {  
            segmentBehind.MoveWormSegment();
            segmentBehind.MoveWorm();
        }
    }

    public void SetSegmentAhead(WormSegment segment) {
        segmentAhead = segment;
    }
}
