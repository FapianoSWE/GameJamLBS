using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameEntityScript : MonoBehaviour {
    EventSystem eventSystem;
    GameObject optionsMenu;
    Slider volumeSlider;
    public GameObject[] buttons;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        optionsMenu = GameObject.Find("Options");
        optionsMenu.SetActive(false);
    }

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if(buttons[i] == eventSystem.currentSelectedGameObject)
            {
                eventSystem.currentSelectedGameObject.GetComponent<Image>().color = Color.blue;
                eventSystem.currentSelectedGameObject.GetComponentInChildren<Text>().color = Color.white;
            }
            else
            {
                buttons[i].GetComponent<Image>().color = Color.white;
                buttons[i].GetComponentInChildren<Text>().color = Color.black;
            }
        }
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
