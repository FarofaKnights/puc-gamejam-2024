using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSwitch : MonoBehaviour, Switchable {
    public void Ativar() {
        RoomManager.instance.FaseEncerrada();
    }

    public void Desativar() {
        //RoomManager.instance.FaseEncerrada();
    }

    public void Switch() {
        //RoomManager.instance.FaseEncerrada();
    }
}
