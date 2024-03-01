using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking;
    private bool isRunning;
    private float velocity;
    public float acceleration = 1;
    public float deceleration = 1;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            velocity = acceleration * Time.deltaTime;
        }
        animator.SetFloat("velocity", velocity);







        //    isWalking = animator.GetBool("isWalking");
        //    if (!isWalking && Input.GetKey(KeyCode.W))
        //    {
        //        animator.SetBool("isWalking", true);
        //    }
        //    if (isWalking && !Input.GetKey(KeyCode.W))
        //    {
        //        animator.SetBool("isWalking", false);
        //    }


    }
}
