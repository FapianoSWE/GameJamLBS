using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    GameObject optionsMenu;
    Slider volumeSlider;
    EventSystem eventSystem;
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
            ButtonJuice();

            if (optionsMenu.activeInHierarchy && Input.GetButtonDown("Cancel"))
            {
                optionsMenu.SetActive(false);
            }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void ButtonJuice()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == eventSystem.currentSelectedGameObject)
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
    }

}
