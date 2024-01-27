using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour, Switchable {
    public GameObject porta;

    void Start() {
        Desativar();
    }

    public void Ativar() {
        Debug.Log("Ativando porta");
        porta.SetActive(false);
    }

    public void Desativar() {
        Debug.Log("Desativando porta");
        porta.SetActive(true);
    }

    public void Switch() {
        porta.SetActive(!porta.activeSelf);
    }
}
