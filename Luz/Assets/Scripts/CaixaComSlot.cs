using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaComSlot : MonoBehaviour {
    public GameObject espelho;
    public Material materialAtivado, materialDesativado;
    public string reflectLayer, groundLayer;
    public string reflectTag, groundTag;

    public bool ativado = false;

    void Start() {
        Desativar();
    }

    public void Ativar() {
        ativado = true;
        espelho.GetComponent<Renderer>().material = materialAtivado;
        GetComponent<EspelhoInteractable>().enabled = true;
        espelho.layer = LayerMask.NameToLayer(reflectLayer);
        espelho.tag = reflectTag;
    }

    public void Desativar() {
        ativado = false;
        espelho.GetComponent<Renderer>().material = materialDesativado;
        GetComponent<EspelhoInteractable>().enabled = false;
        espelho.layer = LayerMask.NameToLayer(groundLayer);
        espelho.tag = groundTag;
    }
}
