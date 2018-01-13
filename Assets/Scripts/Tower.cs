using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int hitPoints;
    public int armor;
    public float fireRate;
    private float fireTimer  = 0;
    private bool playerInRange;

    public GameObject cone;
    public GameObject tower;

    private void FixedUpdate()
    {
        if(playerInRange) {
            fireTimer += Time.fixedDeltaTime;
            if (fireTimer > fireRate) {
                Fire();
            }
        }
    }

    void Fire() {
        Debug.Log("Fire!!");
        ResetTimer();
    }

    public void StartShooting() {
        // we should shoot immediately!
        fireTimer = fireRate;
        playerInRange = true;
    }

    public void StopShooting() {
        playerInRange = false;
    }

    void ResetTimer() {
        fireTimer = 0;
    }


}
