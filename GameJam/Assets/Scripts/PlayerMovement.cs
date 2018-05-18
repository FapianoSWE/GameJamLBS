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
    public Rigidbody2D rb;
    BoxCollider2D collider;
    float raydistance;
    
    //Teleport Variables
    Vector2 currentVelocity;
    float cooldown; 
    public float cooldownTime;


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
            cooldown = cooldownTime;
        }
        else if(Input.GetAxis("RightTrigger") == 1 && cooldown <= 0)
        {
            Teleport(1);
            cooldown = cooldownTime;
        }

        if(cooldown > -1)
        {
            cooldown -= Time.deltaTime;
        }
        raydistance = 1;
        Debug.DrawRay(transform.position, Vector2.down * raydistance, Color.black);

        int lm = 1 << 8;
        lm = ~lm;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raydistance, lm);

        if(hit.collider.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
            
        
	}
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0 || horizontal > 0)
        {
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, 0));
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, jumpForce));
            isGrounded = false;
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
