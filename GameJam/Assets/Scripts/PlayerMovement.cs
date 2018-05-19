using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Movement Variables
    public float speed, maxSpeed;
    public float jumpForce, lowJumpMultiplier, fallMultiplier, maxUpVelocity;
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
        
    }

    void Update()
    {
        CheckGround();
        Movement();
        if (rb.velocity.y > maxUpVelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxUpVelocity);
        }

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
    } 

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            if (rb.velocity.x > -maxSpeed)
            {
                rb.velocity += new Vector2(horizontal * speed * Time.deltaTime, 0);
            }
          
        }
        else if (horizontal > 0)
        {
            if (rb.velocity.x < maxSpeed)
            {
                rb.velocity += new Vector2(horizontal * speed * Time.deltaTime, 0);
            }
        }
        else if (isGrounded == true)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.velocity += new Vector2(0, jumpForce  * 1000 * Time.deltaTime);
        }
        //BetterJumping
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.down * fallMultiplier * Time.deltaTime;
        }
        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.down * lowJumpMultiplier * Time.deltaTime;
        }
    }

    void CheckGround()
    {
        int lm = 1 << 8;
        lm = ~lm;
        RaycastHit2D[] hit = { Physics2D.Raycast(transform.position, Vector2.down,0.1f,lm),
                               Physics2D.Raycast(transform.position + new Vector3(-0.4f, 0, 0), Vector2.down, raydistance, lm),
                               Physics2D.Raycast(transform.position + new Vector3(0.4f, 0, 0), Vector2.down, raydistance, lm)};
        for (int i = 0; i < hit.Length; i++)
        {
            try
            {
                if (hit[i].collider.gameObject.tag == "Terrain")
                {
                    isGrounded = true;
                }
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
            catch { }
        }
    }

    //Direction is 1 for right -1 for left
    void Teleport(float direction)
    {
        transform.position = new Vector2(transform.position.x + (teleportRange * direction), transform.position.y);
    }

    IEnumerator waitForFrame(Collider2D collider)
    {
        yield return new WaitForSeconds(0.2f);
        isGrounded = false;
        yield return new WaitForSeconds(0.3f);
        collider.enabled = true;
    }
}
