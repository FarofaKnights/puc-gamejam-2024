using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspelhoInteractable : MonoBehaviour, Interagivel {
    public GameObject espelho;
    public float[] angulos = new float[] { 30, 15, 0, -15, -30, -45, -60, -75, -90, -105, -120, -135 };
    public int anguloAtual = 0;

    void Start() {
        espelho.transform.localRotation = Quaternion.Euler(0, 0, GetAngulo());
    }
    
    public void Interagir() {
        anguloAtual++;
        if (anguloAtual >= angulos.Length)
            anguloAtual = 0;
        espelho.transform.localRotation = Quaternion.Euler(0, 0, GetAngulo());
    }

    public float GetAngulo() {
        return angulos[anguloAtual];
    }
}
