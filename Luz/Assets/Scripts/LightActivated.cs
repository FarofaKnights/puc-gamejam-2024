using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivated : MonoBehaviour, Switchable {
    public GameObject[] connected;

    public void Ativar() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Ativar();
        }
    }

    public void Desativar() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Desativar();
        }
    }

    public void Switch() {
        foreach (GameObject s in connected) {
            Switchable sw = s.GetComponent<Switchable>();
            sw.Switch();
        }
    }
}
