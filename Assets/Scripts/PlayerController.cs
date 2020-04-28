using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rigidbody;
    Animator animator;
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * 5, rigidbody.velocity.y, Input.GetAxis("Vertical") * 5);
        rigidbody.velocity = moveVector;

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rigidbody.AddForce(new Vector3(0, 1700, 0));
            animator.Play("PlayerJump", -1, 0f);
            
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }

}
