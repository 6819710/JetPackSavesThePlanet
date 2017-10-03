using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class WormSegment : MonoBehaviour {

    public WormSegment wormSegmentPrefab;
    private WormSegment segmentAhead;
    private WormSegment segmentBehind;

	public float wormSpread = 3f; // how far away each segment is

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
		Vector3 direction = (transform.position - targetPos);
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
		transform.position = targetPos + direction.normalized * wormSpread;
    }

    public void ExtendWorm(int currentSize, int maxSize) {
		if (currentSize >= maxSize) {
			this.transform.localScale /=2; // tail will look half the size
			return;
		}
		WormSegment newSegment = Instantiate(wormSegmentPrefab, transform.parent);
        newSegment.name = "worm-segment-" + currentSize;
        newSegment.SetSegmentAhead(this);
        segmentBehind = newSegment;
		if (!segmentAhead) {
			newSegment.transform.localPosition = 2 * wormSpread * (transform.position - Vector3.up).normalized;
		} else {
			newSegment.transform.localPosition = wormSpread * (transform.position - segmentAhead.transform.position).normalized;
			newSegment.transform.localScale = -segmentAhead.transform.localScale; // each segment is a flip of the previous
		}
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
