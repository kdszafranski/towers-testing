using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TowerArrow") {
            Debug.Log("Been shot by an arrow");
            Destroy(other.gameObject);
        }
    }


}
