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
            //float vertical = Input.GetAxis("Vertical");
            // control max velocity

            // point at and go where we clicked
            if(Input.GetMouseButton(0)) {
                // raycast to ground
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log(hit.transform.name);

                    if (rBody.velocity.magnitude < maxVelocity) {
                        // face where we clicked
                        gameObject.transform.LookAt(hit.point);

                        // force pushes us forward (whichever direction gameObject is facing)
                        rBody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 2500f);
                    }
                }
            }

            //float horizontal = Input.GetAxis("Horizontal");

            //// rotate us around the Y (Vector3.up) axis
            //transform.Rotate(0, 2f * horizontal, 0);

        }
	}
}
