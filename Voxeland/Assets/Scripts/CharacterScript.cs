using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharacterScript : MonoBehaviour
{
    public float velocity;
    public float turnSpeed;

    public float angle;

    public Quaternion targetRotation;
    public Transform cam;

    public Animator anim;

    public bool isJumping;
    public bool isTalking;

    Rigidbody body;


    public void Start()
    {
        velocity = 10;
        turnSpeed = 10;
        cam = Camera.main.transform;
        body = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        isJumping = false;
        isTalking = false;
    }

    private void Update()
    {
        if (!isTalking)
        {
            if (Input.GetKey(KeyCode.Space) && !isJumping)
            {
                anim.SetBool("IsJumping", true);
                anim.SetTrigger("Jump");
                isJumping = true;
            }

            float xMove = Input.GetAxisRaw("Horizontal");
            float yMove = Input.GetAxisRaw("Vertical");

            angle = Mathf.Rad2Deg * Mathf.Atan2(xMove, yMove);
            angle += cam.eulerAngles.y;

            if (Mathf.Abs(xMove) < 1 && Mathf.Abs(yMove) < 1)
            {
                anim.SetBool("isWalking", false);
                return;
            };

            targetRotation = Quaternion.Euler(0, angle, 0);

            body.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            body.MovePosition(transform.position + transform.forward * Time.deltaTime * velocity);
            anim.SetBool("isWalking", true);
        }
    }
}