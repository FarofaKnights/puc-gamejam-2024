using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public PlayerMovement p1, p2;

    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        if (RoomManager.instance.currentRoom == 0) {
            UIController.instance.ShowHaikou("Apenas um de nós pode sair daqui", UIController.HaikouType.One);
        }
    }
}
