using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private PlayerBasic player;
    private GameObject deathMenu;
    private GameObject deathBlur;

    private bool deathCalled = false;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBasic>();

        Time.timeScale = 1;
        deathMenu = GameObject.Find("DeathMenu");
        deathBlur = GameObject.Find("DeathBlur");

        deathMenu.SetActive(false);
        deathBlur.SetActive(false);
    }

    private void Update()
    {
        if (checkPlayerHealth() <= 0 && deathCalled == false)
        {
            //print("death time");
            playerDead();
        }
    }

    private float checkPlayerHealth()
    {
        HealthSystem playerHs = player.GetComponent<HealthSystem>();
        return playerHs.getHealth();
    }

    private void playerDead()
    {
        deathMenu.SetActive(true);
        deathBlur.SetActive(true);

        Time.timeScale = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
