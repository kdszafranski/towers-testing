using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

    Rigidbody rBody;
    public float maxVelocity = 30f;
    public Vector3 currentMoveToLocation; // should not be public
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
                        currentMoveToLocation = new Vector3(hit.point.x, gameObject.transform.position.y, hit.point.z);

                        // show visual location marker
                        movementMarker.transform.position = new Vector3(currentMoveToLocation.x, currentMoveToLocation.y + 5f, currentMoveToLocation.z);
                        movementMarker.SetActive(true);
                    }
                }
            } // end mouse down

            // have we arrived at the target location?
            if (HasArrivedAtTargetLocation()) {
                // arrived, reset marker
                if(movementMarker.activeSelf) {
                    Debug.Log("Arrived");
                    movementMarker.SetActive(false);
                }
            } else {
                // no, keep on movin'
                Move();
            }
        
        }
	}

    bool HasArrivedAtTargetLocation() {
        // get current values of player object and target position
        float x = Mathf.Round(gameObject.transform.position.x);
        float z = Mathf.Round(gameObject.transform.position.z);
        float targetX = Mathf.Round(currentMoveToLocation.x);
        float targetZ = Mathf.Round(currentMoveToLocation.z);

        // ignore y (vertical height)
        if(targetX == x && targetZ == z) {
            // we have arrived
            return true;
        }

        return false;
    }

    void Move() {
        // whether we clicked or not, move toward our current target position
        if (currentMoveToLocation != null) {
            gameObject.transform.LookAt(currentMoveToLocation);
            // force pushes us forward (whichever direction gameObject is facing)
            rBody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 2500f);
        }

    }
}
