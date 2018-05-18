using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Vector2 addDistance;
    public Transform connectedDoor;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
            col.gameObject.transform.position = (Vector2)connectedDoor.position + addDistance;
        }     
    }
}
