using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecedor : MonoBehaviour, Switchable {
    public GameObject obj;
    public bool mostrarUnico = false;
    bool podeDesmostrar = true;

    void Start() {
        Desativar();
    }

    public void Ativar() {
        obj.SetActive(true);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }

        if (mostrarUnico) podeDesmostrar = false;
    }

    public void Desativar() {
        if (!podeDesmostrar) return;
        obj.SetActive(false);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    public void Switch() {
        if (!obj.activeSelf) {
            Ativar();
        } else {
            Desativar();
        }
    }
}
