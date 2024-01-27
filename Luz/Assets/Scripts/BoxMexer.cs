using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMexer : MonoBehaviour {
    public LayerMask mexiveisLayer;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f, mexiveisLayer);
            if (hitColliders.Length > 0) {
                hitColliders[0].GetComponent<Interagivel>().Interagir();
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
