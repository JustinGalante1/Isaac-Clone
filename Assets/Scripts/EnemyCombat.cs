using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private HealthSystem hs;

    public bool isChampion;

    private void Start()
    {
        hs = this.GetComponent<HealthSystem>();
    }

    private void LateUpdate()
    {
        if(hs.getHealth() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

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
