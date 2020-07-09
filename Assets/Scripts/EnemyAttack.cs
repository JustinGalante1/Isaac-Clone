using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool isChampion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            HealthSystem playerHs = collision.collider.GetComponent<HealthSystem>();
            if (isChampion)
            {
                playerHs.damage(20);
            }
            else
            {
                playerHs.damage(10);
            }
            if (playerHs.getGracePeriod() <= 0)
            {
                playerHs.setGracePeriod();
            }
        }
    }
}
