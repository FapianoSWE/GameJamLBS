using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour {

    public float bulletVelocity;
    public GameObject bulletPrefab;
    GameObject bullets;
    public Animator anim;

    void start()
    {
        bullets = new GameObject();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
            bullet.GetComponent<BulletScript>().velocity = new Vector2(bulletVelocity * transform.localScale.x, 0);
            anim.SetBool("Shooting",true);
            StartCoroutine("ResetBool");
        }
	}

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.5f);
        print("Tried Reset");
        anim.SetBool("Shooting",false);
    }
}
