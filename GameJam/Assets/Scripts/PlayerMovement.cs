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

    //Teleport Variables
    Vector2 currentVelocity;
    float cooldown;


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
		if(Input.GetAxis("LeftTrigger") == 1 && cooldown <= 0)
        {
            Teleport(-1);
            cooldown = 5;
        }
        else if(Input.GetAxis("RightTrigger") == 1 && cooldown <= 0)
        {
            Teleport(1);
            cooldown = 5;
        }

        if(cooldown > -1)
        {
            cooldown -= Time.deltaTime;
        }
        Debug.Log(cooldown);

	}
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0 || horizontal > 0)
        {
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, 0));
        }
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, jumpForce));
        }
    }

    //Direction is 1 for right -1 for left
    void Teleport(float direction)
    {
        currentVelocity = rb.velocity;
        transform.position = new Vector2(transform.position.x + (teleportRange * direction), transform.position.y);
        rb.velocity = currentVelocity;
    }
}
