using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Movement Variables
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    public Vector2 moveDirection;
    public float teleportRange;

    //Physics
    Rigidbody2D rb;
    BoxCollider2D collider;


	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
	}

    void FixedUpdate()
    {
        Movement();
    }

    void Update ()
    {
		if(Input.GetAxis("Left Trigger") == 1)
        {
            Teleport(-1);
        }
        else if(Input.GetAxis("Right Trigger") == 1)
        {
            Teleport(1);
        }
	}
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0 || horizontal > 0)
        {
            rb.AddForce(new Vector2(horizontal * speed, 0));
        }
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(horizontal * speed, jumpForce));
        }
    }

    //Direction is 1 for right -1 for left
    void Teleport(float direction)
    {
        transform.position = new Vector2(transform.position.x + teleportRange * direction, transform.position.y);
    }
}
