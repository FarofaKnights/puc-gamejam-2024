using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSphere : MonoBehaviour {
    public float speed;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        Vector3 dir = transform.right;
        rb.velocity = dir * speed;
    }
}
