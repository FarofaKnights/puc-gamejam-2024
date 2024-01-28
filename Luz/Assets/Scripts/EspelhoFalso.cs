using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspelhoFalso : MonoBehaviour, Switchable {
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Ativar() {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void Desativar() { }
    
    public void Switch() { }
}
