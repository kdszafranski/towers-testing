using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    Rigidbody rBody;
    public float maxVelocity = 30f;
    Vector3 currentMoveToLocation;
    public GameObject movementMarker;

	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody>();
        currentMoveToLocation = gameObject.transform.position;
        movementMarker.SetActive(false);
	}

    // Update is called once per frame
    void FixedUpdate() {
        if(rBody != null) {

            // point at and go where we clicked
            if(Input.GetMouseButton(0)) {
                // raycast to ground
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log(hit.transform.name);

                    if (rBody.velocity.magnitude < maxVelocity) {
                        // set this as our current goal position
                        currentMoveToLocation = hit.point;

                        // show visual location marker
                        movementMarker.transform.position = new Vector3(currentMoveToLocation.x, currentMoveToLocation.y + 5f, currentMoveToLocation.z);
                        movementMarker.SetActive(true);
                    }
                }
            }

            // TODO need a better way to check they have arrived at the correct spot and not keep spinning.
            if(currentMoveToLocation != gameObject.transform.position) {
                Move();
            } else {
                movementMarker.SetActive(false);
            }
        }
	}

    void Move() {
        gameObject.transform.LookAt(movementMarker.transform.position);

        // whether we clicked or not, move toward our current target position
        if (currentMoveToLocation != null) {
            // force pushes us forward (whichever direction gameObject is facing)
            rBody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 2500f);
        }

    }
}
