using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {

    SceneManager sceneManager;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
