using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public enum Player { One, Two }
    public Player player = Player.One;
    public bool usingAlt = false;

    public float walkSpeed = 7f, runSpeed = 12f;
    public float jumpForce = 10f, gravity = 10f;
    CharacterController controller;
    bool jumping = false;

    Vector3 moveDirection;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    string CurrentPlayer() {
        return player == Player.One ? "p1" : "p2";
    }

    string UsingAlt() {
        return usingAlt ? "_alt" : "";
    }

    void Update() {
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
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

            if (Input.GetButton(CurrentPlayer() + "_Jump")) {
                moveDirection.y = jumpForce;
                jumping = true;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}
