using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationScript : MonoBehaviour {

    public List<GameObject> LevelModules;

    public int levelLength;

    void Start () {
        int lastRoom = LevelModules.Count + 1;
        for (int i = 0; i<levelLength; i++)
        {
            int room = Random.Range(0,LevelModules.Count);
            while (room == lastRoom)
            {
                room = Random.Range(0, LevelModules.Count);
            }        
            GameObject Room = Instantiate(LevelModules[room], new Vector2(18*i,0), Quaternion.identity);
            lastRoom = room;
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
