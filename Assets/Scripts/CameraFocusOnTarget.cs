using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusOnTarget : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
        if(target) {
            transform.LookAt(target.transform.position);
        }	
	}

    private void FixedUpdate() {
        if(target) {
            transform.LookAt(target.transform.position);
        }
    }
}
