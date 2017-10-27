using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	private float parallaxScales;	
	public float smoothing = 1f;	
	private Transform cam;
	private Vector3 previousCamPos;	

	void Awake() {
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
		parallaxScales = transform.position.z;
	}

	void Update() {
		float parallaxX =  (previousCamPos.x - cam.position.x) * parallaxScales;
		float parallaxY =  (previousCamPos.y - cam.position.y) * parallaxScales;
		float backgroundTargetPosX = transform.position.x + parallaxX;
		float backgroundTargetPosY = transform.position.y + parallaxY;
		Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgroundTargetPosY, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, backgroundTargetPos, smoothing * Time.deltaTime);
		previousCamPos = cam.position;
	}
}
