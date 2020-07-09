using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken: MonoBehaviour
{
    private float damage;

    private float lifeTimer = 100;

    private Rigidbody2D rb;

    private void Update()
    {
        if(lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if(lifeTimer > 0)
        {
            lifeTimer -= Time.deltaTime * 29.5f;
        }
    }

    public void setLifeTimerFromRange(float range)
    {
        this.lifeTimer = range;
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        if(collision.collider.tag == "Enemy")
        {
            HealthSystem hs = collision.collider.GetComponent<HealthSystem>();
            hs.damage(this.damage);
        }
    }
}
