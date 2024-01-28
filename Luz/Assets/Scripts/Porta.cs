using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour, Switchable {
    public GameObject porta;
    public bool aberturaUnica = false;
    bool podeFechar = true;

    void Start() {
        Desativar();
    }

    public void Ativar() {
        porta.SetActive(false);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }

        if (aberturaUnica) podeFechar = false;
    }

    public void Desativar() {
        if (!podeFechar) return;
        porta.SetActive(true);
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }

    public void Switch() {
        if (porta.activeSelf) {
            Ativar();
        } else {
            Desativar();
        }
    }
}
