using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerBasic player;

    private void Update()
    {
        if (checkPlayerHealth() <= 0)
        {
            print("player dead");
        }
    }

    private float checkPlayerHealth()
    {
        HealthSystem playerHs = player.GetComponent<HealthSystem>();
        return playerHs.getHealth();
    }
}
