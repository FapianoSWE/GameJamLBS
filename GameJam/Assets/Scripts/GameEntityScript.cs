using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameEntityScript : MonoBehaviour {

    GameObject optionsMenu;
    Slider volumeSlider;

    void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        optionsMenu = GameObject.Find("Options");
        optionsMenu.SetActive(false);
    }

    void Update()
    {
        
        
        DontDestroyOnLoad(gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }
    public void VolumeSlider()
    {

    }
}
