using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    Rigidbody rBody;
    public float maxVelocity = 30f;

	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        if(rBody != null) {
            // -1 to 1, used as a multiplier below
            float vertical = Input.GetAxis("Vertical");
            // control max velocity
            if(rBody.velocity.magnitude < maxVelocity) {
                // force pushes us forward (whichever direction gameObject is facing)
                rBody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 2500f * vertical);    
            }

            float horizontal = Input.GetAxis("Horizontal");

            // rotate us around the Y (Vector3.up) axis
            transform.Rotate(0, 2f * horizontal, 0);
                //new Vector3(transform.rotation.x, transform.rotation.y + 2f * horizontal, transform.rotation.z));

        }
	}
}
