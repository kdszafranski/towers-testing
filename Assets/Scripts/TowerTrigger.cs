using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour {


    public GameObject parentTower;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            //Debug.Log("TowerTrigger in range of player.");
            parentTower.GetComponent<Tower>().StartShooting(other.gameObject);    
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            //Debug.Log("TowerTrigger OUT OF RANGE.");
            parentTower.GetComponent<Tower>().StopShooting();    
        }

    }
}
