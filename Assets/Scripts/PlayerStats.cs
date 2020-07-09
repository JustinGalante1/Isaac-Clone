using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float speed = 1;
    private float range = 20;
    private float shotSpeed = 12;
    private float damage = 5;
    private float fireRate = 10f;

    public float getSpeed()
    {
        return this.speed;
    }

    public float getRange()
    {
        return this.range;
    }

    public float getShotSpeed()
    {
        return this.shotSpeed;
    }

    public float getDamage()
    {
        return this.damage;
    }

    public float getFireRate()
    {
        return this.fireRate;
    }
}
