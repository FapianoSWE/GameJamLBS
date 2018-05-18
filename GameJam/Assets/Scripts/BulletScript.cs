using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


    public Vector2 velocity;
	void Update () {
        transform.Translate(velocity * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Terrain"))
        {
            Destroy(gameObject,0f);
        }
    }
}
