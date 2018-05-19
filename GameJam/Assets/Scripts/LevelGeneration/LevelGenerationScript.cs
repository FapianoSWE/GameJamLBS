using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationScript : MonoBehaviour {

    public List<GameObject> LevelModules;

    public int levelLength;

    void Start () {
        GameObject map = new GameObject();
        int lastRoom = LevelModules.Count + 1;
        for (int i = 0; i<levelLength; i++)
        {
            int room = Random.Range(0,LevelModules.Count);
            while (room == lastRoom)
            {
                room = Random.Range(0, LevelModules.Count);
            }       
            if (room == 3|| room == 4 || room == 5)
            {
                if (lastRoom == 3 || lastRoom == 4 || lastRoom == 5)
                {
                    room = Random.Range(0, 2);
                }
            } 
            GameObject Room = Instantiate(LevelModules[room], new Vector2(18*i,0), Quaternion.identity);
            Room.transform.SetParent(map.transform);
            lastRoom = room;
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
