using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAggression : MonoBehaviour {

    EnemyBehaviourScript ebs;    
	void Start () {
		ebs = transform.parent.GetComponent<EnemyBehaviourScript>();
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ebs.currentState = EnemyBehaviourScript.EnemyState.aggressive;
        }   
    }
}
