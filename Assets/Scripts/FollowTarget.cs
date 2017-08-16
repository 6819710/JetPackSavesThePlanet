using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    //public float lazinessFactor = 0.5f;
    public float speed;
    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().MovePosition(transform.position + speed*Time.deltaTime * (targetPos - transform.position).normalized);
        //    if (target != null) {
        //        Vector3 velocity = Vector3.zero;
        //        Vector3 forward = target.transform.forward * 10.0f;
        //        Vector3 needPos = target.transform.position - forward;
        //        transform.position = Vector3.SmoothDamp(transform.position, needPos, ref velocity, lazinessFactor);
        //        transform.LookAt(target.transform);
        //        transform.rotation = target.transform.rotation;
        //    }
        //}
    }
}
