using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
            if (!pm.holdingShard) {
                pm.holdingShard = true;
                Destroy(gameObject);
            }
        }
    }
}
