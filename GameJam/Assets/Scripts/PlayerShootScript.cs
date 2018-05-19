using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

    public float bulletVelocity;
    public GameObject bulletPrefab;
    public Animator anim;
    GameObject bullets;



    void start()
    {
        bullets = new GameObject();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetFloat("Shoot", 1);
            GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
            bullet.GetComponent<BulletScript>().velocity = new Vector2(bulletVelocity * transform.localScale.x, 0);
            StartCoroutine("ResetAnimValue");
        }
	}

    IEnumerator ResetAnimValue()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetFloat("Shoot", -1);
    }
}
