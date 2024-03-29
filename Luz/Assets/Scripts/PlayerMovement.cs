using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public enum Player { One, Two }
    public Player player = Player.One;
    public bool usingAlt = false;

    public float walkSpeed = 7f, slowSpeed = 1.25f;
    public float jumpForce = 10f, gravity = 10f;
    CharacterController controller;
    bool jumping = false;
    public bool isSlow = false;


    // Principio de responsabilidade fodase
    public bool holdingShard = false;


    Vector3 moveDirection;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    string CurrentPlayer() {
        return player == Player.One ? "p1" : "p2";
    }

    string UsingAlt() {
        return usingAlt ? "" : "";
    }

    public void UseShard() {
        holdingShard = false;
    }

    void Update() {
        float moveSpeed = isSlow ? slowSpeed : walkSpeed;
        float hAxis = Input.GetAxis(CurrentPlayer() + "_Horizontal" + UsingAlt()) * moveSpeed;
        float vAxis = 0;

        if (jumping && controller.collisionFlags == CollisionFlags.Above && moveDirection.y > 0) {
            moveDirection.y = 0;
        }
        
        float y = controller.isGrounded ? 0 : moveDirection.y;
        moveDirection = new Vector3(hAxis, y, vAxis);
        moveDirection = transform.TransformDirection(moveDirection);

        if (controller.isGrounded) {
            if (jumping) jumping = false;

            if (Input.GetButton(CurrentPlayer() + "_Jump" + UsingAlt())) {
                if (GetComponent<BoxPusher>() != null && GetComponent<BoxPusher>().box != null) {
                    GetComponent<BoxPusher>().Soltar();
                }

                moveDirection.y = jumpForce;
                jumping = true;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
