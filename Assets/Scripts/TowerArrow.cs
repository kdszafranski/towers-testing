using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArrow : MonoBehaviour {

    Rigidbody rb;
    public float damageDealt;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(rb) {
            if(rb.velocity.magnitude <= 0) {
                Destroy(gameObject);
            }
        }
	}
}
