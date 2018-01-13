using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int hitPoints;
    public int armor;
    public float fireRate;
    public bool playerInRange;

    public GameObject cone;
    public GameObject tower;

    private void FixedUpdate()
    {
        if(playerInRange) {
            Debug.Log("Shoot at player");
        }
    }



}
