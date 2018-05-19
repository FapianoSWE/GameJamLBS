using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


    public Vector2 velocity;
    public float lifeTime;

    void Awake()
    {
        Destroy(gameObject,lifeTime);
    }

	void Update () { 

        transform.Translate(velocity * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        print(col.gameObject.layer);
        if (col.gameObject.layer == 11)
        {
            col.gameObject.GetComponent<EnemyBehaviourScript>().health -= 1;
        }
        Destroy(gameObject,0f);
    }
}
