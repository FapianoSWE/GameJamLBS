using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour {

    //Enums
    public enum EnemyState
    {
        patrolling,
        aggressive,
    }
    public EnemyState currentState = EnemyState.patrolling;

    //Patrol Related Variables
    public Transform patrol1, patrol2, gunPos, particlePos;
    Transform patrolTarget;

    //Public Variables
    public float accelerationSpeed, maxSpeed, attackRate, shotSpeed;
    public GameObject projectile, deathParticle;
    public int health;
    public AudioClip deathSound;

    //Local Variables
    float attackTimer;
    Rigidbody2D rb;
    GameObject player;


    GameObject coin;

	void Start () {
        patrolTarget = patrol1;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        coin = GameObject.Find("Main GameEntity").GetComponent<GlobalVariables>().coins;
	}
	
	// Update is called once per frame
	void Update () {
        if (health > 0)
        {
            if (currentState == EnemyState.patrolling)
            {
                #region Patrolling
                if (patrolTarget.position.x > transform.position.x)
                {
                    if (rb.velocity.x < maxSpeed)
                    {
                        rb.AddForce(new Vector2(accelerationSpeed, 0));
                    }
                    else
                    {
                        rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
                    }
                }
                else
                {
                    if (rb.velocity.x > -maxSpeed)
                    {
                        rb.AddForce(new Vector2(-accelerationSpeed, 0));
                    }
                    else
                    {
                        rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
                    }
                }
                #endregion
            }
            else if (currentState == EnemyState.aggressive)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackRate)
                {
                    GameObject bullet = Instantiate(projectile, gunPos.position, Quaternion.identity);
                    Vector2 directionVector = player.transform.position - gunPos.position;
                    directionVector.Normalize();

                    bullet.GetComponent<BulletScript>().velocity = directionVector * shotSpeed;

                    attackTimer = 0;
                }
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            GameObject part = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(part, 5);
            GameObject temp = Instantiate(coin, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject,0);
        }
    }      


    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collided");

        if(col.gameObject.tag == "PatrolPoint")
        {
            if (patrolTarget == patrol1)
            {
                patrolTarget = patrol2;
            }
            else
            {
                patrolTarget = patrol1;
            }
        }   
    }
}
