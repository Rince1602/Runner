using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private float gravity;
    private Vector3 directoin;
    private CharacterController characterController;
    private Animator animator;
    private MobileController mobileController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mobileController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    private void Update()
    {
        PlayerMove();
        Gravity();
    }

    private void PlayerMove()
    {
        directoin = Vector3.zero;
        directoin.x = mobileController.Horizontal() * speed;
        directoin.z = mobileController.Vertical() * speed;

        if (directoin.x != 0 || directoin.y != 0)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);

        if (Vector3.Angle(Vector3.forward, directoin) > 1f || Vector3.Angle(Vector3.forward, directoin) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, directoin, speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        directoin.y = gravity;
        characterController.Move(directoin * Time.deltaTime);
    }

    private void Gravity()
    {
        if (!characterController.isGrounded)
            gravity -= 20f * Time.deltaTime;
        else
            gravity = -1f;
    }

    /*public void Run()
    {
        speed = 5f;
        animator.SetBool("Run", true);
    }*/
}
