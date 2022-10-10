using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothSpeed = 0.0625f;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = new Vector3 (transform.position.x ,transform.position.y, Mathf.Lerp(transform.position.z, desiredPosition.z, smoothSpeed));

        transform.position = smoothPosition;
        
	}
}
