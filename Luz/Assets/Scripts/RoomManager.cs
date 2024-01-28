using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public static RoomManager instance;

    public bool rodando = true;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }


    public void FaseEncerrada() {
        rodando = false;
    }
}
