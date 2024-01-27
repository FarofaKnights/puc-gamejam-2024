using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, Switchable {
    public GameObject[] connected;
    public GameObject visual;

    public void Ativar() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Ativar();
        }

        visual.transform.localPosition = new Vector3(0, -0.1f, 0);
    }

    public void Desativar() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Desativar();
        }

        visual.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void Switch() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Switch();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box")) {
            Ativar();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box")) {
            Desativar();
        }
    }
}
