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

    public GameObject arrowPrefab;

    GameObject player;

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
        if(player) {
            // instantiate arrow
            GameObject arrow = Instantiate(arrowPrefab, gameObject.transform.position, Quaternion.identity);
            arrow.transform.LookAt(player.transform);

            Rigidbody rBody = arrow.GetComponent<Rigidbody>();
            if(rBody) {
                rBody.AddForce(new Vector3(arrow.transform.forward.x, 0, arrow.transform.forward.z) * 6000f);
            }
        }

        ResetTimer();
    }

    public void StartShooting(GameObject playerObj) {
        // we should shoot immediately!
        if(playerObj != null) {
            player = playerObj;
            fireTimer = fireRate;
            playerInRange = true;    
        }
    }

    public void StopShooting() {
        player = null;
        playerInRange = false;
    }

    void ResetTimer() {
        fireTimer = 0;
    }


}
