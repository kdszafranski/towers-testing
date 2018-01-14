using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour 
{
    Camera cam;
    public GameObject target;
    public float cameraPanSpeed = 0.2f;
    public float constantHeight;
    public float minDistance = 40f;

    // Use this for initialization
    void Awake() {
        cam = Camera.main;
    }

    public void SetTarget(GameObject go) {
        target = go;
    }

    public void ResetToStart() {
        cam.transform.position = new Vector3(0, 0, -10);
    }

    void Update() {
        if (target != null) {
            // Smooth out our position and following the player
            Vector3 velocity = Vector3.zero;
            Vector3 forward = target.transform.forward * 10.0f;
            Vector3 needPos = target.transform.position - forward;

            // never get closer than constantHeight
            Vector3 finalNeedPos = new Vector3(needPos.x, constantHeight, needPos.z);

            // always look at the target
            cam.transform.LookAt(target.transform.position);

            // don't get too close
            if (Vector3.Distance(cam.transform.position, finalNeedPos) > minDistance) {
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, finalNeedPos, ref velocity, cameraPanSpeed);
            }

        }
    }
}
