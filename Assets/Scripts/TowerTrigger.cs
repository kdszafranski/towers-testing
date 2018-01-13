using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour {


    public GameObject parentTower;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("TowerTrigger in range of player.");
        parentTower.GetComponent<Tower>().playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TowerTrigger OUT OF RANGE.");
        parentTower.GetComponent<Tower>().playerInRange = false;
    }
}
