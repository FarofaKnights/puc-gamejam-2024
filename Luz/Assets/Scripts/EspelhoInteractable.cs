using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspelhoInteractable : MonoBehaviour, Interagivel {
    public GameObject espelho, shardPrefab;
    public float fallToBreak = 5f;
    public float[] angulos = new float[] { 30, 15, 0, -15, -30, -45, -60, -75, -90, -105, -120, -135 };
    public int anguloAtual = 0;

    void Start() {
        espelho.transform.localRotation = Quaternion.Euler(0, 0, GetAngulo());
    }
    
    public void Interagir() {
        if (GetComponent<CaixaComSlot>() != null && !GetComponent<CaixaComSlot>().ativado) {
            PlayerMovement p2 = GameManager.instance.p2;
            if (p2.holdingShard) {
                p2.UseShard();
                GetComponent<CaixaComSlot>().Ativar();
            } else return;
        }

        anguloAtual++;
        if (anguloAtual >= angulos.Length)
            anguloAtual = 0;
        espelho.transform.localRotation = Quaternion.Euler(0, 0, GetAngulo());
    }

    public float GetAngulo() {
        return angulos[anguloAtual];
    }

    void OnCollisionEnter(Collision other) {
        float fall = other.relativeVelocity.y;
        
        if (other.gameObject.GetComponent<SafeGrounds>() != null) {
            fall = 0;
        }

        if (fall > fallToBreak) {
            GameObject shard = Instantiate(shardPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
