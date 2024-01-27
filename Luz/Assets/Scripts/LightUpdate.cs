using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpdate : MonoBehaviour {
    public ParticleSystem ps;

    void Start() {
        ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        ps.Clear();
        ps.Simulate(10f,true,true);
    }
}
