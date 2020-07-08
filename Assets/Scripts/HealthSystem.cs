using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float healthMax;

    private float gracePeriod = 0;

    public Slider healthBar;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public float getHealth()
    {
        return this.health;
    }

    public void setHealthMax(int healthMax)
    {
        this.healthMax = healthMax;
    }

    public float getHealthMax()
    {
        return this.healthMax;
    }

    public void damage(int damage)
    {
        if(gracePeriod <= 0)
        {
            this.health -= damage;
            setHealthDisplay();
        }
    }

    public void heal(int amount)
    {
        this.health += amount;
        setHealthDisplay();
    }

    public float getPercent()
    {
        //print(this.health / this.healthMax);
        return this.getHealth() / this.getHealthMax();
    }

    public void setGracePeriod()
    {
        this.gracePeriod = 1;
    }

    public float getGracePeriod()
    {
        return this.gracePeriod;
    }

    public void setHealthDisplay()
    {
        healthBar.value = getPercent();
    }

    private void printHealth()
    {
        Debug.Log(this.health);
    }

    private void LateUpdate()
    {
        if(gracePeriod > 0)
        {
            gracePeriod -= Time.deltaTime;
        }
    }

}
