using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameObject[] hearts;
    public GameObject[] cooldownUIElements;
    public int health = 3;
    public bool isDead;
    PlayerMovement playerMovement;
    public int coins;
    public Text coinAmount;
    bool canSetFill = true;
	void Start ()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
	}
	



	void Update ()
    {
        Hearts();

        if(playerMovement.cooldown > 0)
        {
            Cooldown();
        }
        else if(playerMovement.cooldown <= 0)
        {
            cooldownUIElements[0].SetActive(false);
            canSetFill = true;
        }
        
        coinAmount.text = coins.ToString();

    }

    void Cooldown()
    {
        if(canSetFill)
        {
            cooldownUIElements[0].SetActive(true);
            cooldownUIElements[0].GetComponent<Image>().fillAmount = 1f;
            canSetFill = false;
        }
        cooldownUIElements[0].GetComponent<Image>().fillAmount = cooldownUIElements[0].GetComponent<Image>().fillAmount - (1 / 3) * Time.deltaTime;
    }


    void Hearts()
    {

        if (health == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
        }
        else if (health == 2)
        {

            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
        }
        else if (health == 1)
        {

            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
        else if (health <= 0)
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            health -= 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            health += 1;
        }

        if (health > 3)
        {
            health = 3;
        }

    }
}
