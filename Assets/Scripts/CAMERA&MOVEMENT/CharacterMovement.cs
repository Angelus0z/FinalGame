using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController Controller;
    [SerializeField]private Animator anim;

    public float speed = 5f;
    public float turnSpeed = 180f;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir;
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;

        Controller.Move(moveDir * Time.deltaTime - Vector3.up * 0.1f);

        if (moveDir != Vector3.zero)
        {
            GetComponent<Animator>().Play("Run");
        }
        else
        {
            GetComponent<Animator>().Play("Idle");
        }
    }
}
