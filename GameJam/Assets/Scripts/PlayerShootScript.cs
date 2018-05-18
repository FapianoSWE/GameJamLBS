using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

    public float bulletVelocity;
    public GameObject bulletPrefab;
    GameObject bullets;

    void start()
    {
        bullets = new GameObject();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
            bullet.GetComponent<BulletScript>().velocity = new Vector2(bulletVelocity,0);
        }
	}
}
