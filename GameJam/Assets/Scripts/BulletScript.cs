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

        Destroy(gameObject,0f);
    }
}
