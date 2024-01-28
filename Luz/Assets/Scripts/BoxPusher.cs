using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPusher : MonoBehaviour {
    public LayerMask mexiveisLayer;
    public float interactRadius = 1.25f;
    public float pushPower = 2.0f;

    public GameObject box;
    public GameObject mao;

    void Update() {
        if (!RoomManager.instance.rodando) {
            if (box != null) {
                Soltar();
            }
            return;
        }

        if (box == null && Input.GetKeyDown(KeyCode.LeftShift)) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRadius, mexiveisLayer);
            if (hitColliders.Length > 0 && hitColliders[0].gameObject.tag == "Box") {
                box = hitColliders[0].gameObject;
                box.transform.parent = mao.transform;
                GetComponent<PlayerMovement>().isSlow = true;
            }
        }

        if (box != null && Input.GetKeyUp(KeyCode.LeftShift)) {
            Soltar();
        }
    }

    public void Soltar() {
        if (box != null) {
            box.transform.parent = null;
            box = null;
            GetComponent<PlayerMovement>().isSlow = false;
        }
    }

    public void CaixaSofreuColissao(Collision other) {
        if (box==null) return;

        // if box collides, make pusher have same velocity (if it stops them pusher stops too)
        if (other.gameObject == box) {
            GetComponent<CharacterController>().Move(other.relativeVelocity * Time.deltaTime);
        }
        
    }
}
