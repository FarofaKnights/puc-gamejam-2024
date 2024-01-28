using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public PlayerMovement p1, p2;

    public GameObject haikouSom, levelSom;

    public bool pausado = false;

    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        if (RoomManager.instance.currentRoom == 0) {
            RoomManager.instance.rodando = false;
            pausado = true;
            UIController.instance.ShowHaikou("Apenas um de nós pode sair daqui", UIController.HaikouType.One);
            haikouSom.SetActive(true);

            UIController.instance.onEndHaikou = () => {
                haikouSom.SetActive(false);
                levelSom.SetActive(true);
                RoomManager.instance.rodando = true;
                pausado = false;

                UIController.instance.ShowTutorial();
            };
        }
    }
}
