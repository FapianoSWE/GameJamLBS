﻿using System.Collections;
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
    public float raydistance;
    
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

    void Update()
    {
        if (Input.GetAxis("LeftTrigger") == 1 && cooldown <= 0)
        {
            Teleport(-1);
            cooldown = 5;
        }
        else if (Input.GetAxis("RightTrigger") == 1 && cooldown <= 0)
        {
            Teleport(1);
            cooldown = 5;
        }

        if (cooldown > -1)
        {
            cooldown -= Time.deltaTime;
        }

        raydistance = 0.5f;
        Debug.DrawRay(transform.position, Vector2.down * raydistance, Color.black);

        int lm = 1 << 8;
        lm = ~lm;
        RaycastHit2D[] hit = { Physics2D.Raycast(transform.position, Vector2.down, raydistance, lm),
                               Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0, 0), Vector2.down, raydistance, lm),
                               Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector2.down, raydistance, lm)};
        for (int i = 0; i < hit.Length; i++)
        {

            if (hit[i].collider.gameObject.tag == "Terrain")
            {
                isGrounded = true;
            }
            //print(Input.GetAxis("Vertical"));
            if (isGrounded && Input.GetAxis("Vertical") <= -0.8f)
            {
                print(hit[i].transform.gameObject.GetComponent<PlatformEffector2D>());
                if (hit[i].transform.gameObject.GetComponent<PlatformEffector2D>() != null)
                {

                    hit[i].collider.enabled = false;
                    StartCoroutine(waitForFrame(hit[i].collider));
                }
            }
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

    IEnumerator waitForFrame(Collider2D collider)
    {
        yield return new WaitForSeconds(0.2f);
        isGrounded = false;
        yield return new WaitForSeconds(0.3f);
        collider.enabled = true;
    }
}
