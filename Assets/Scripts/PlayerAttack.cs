using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject shurikenPrefab;

    private PlayerStats ps;

    private GameObject playerFace;

    private float fireTimer;

    void Start()
    {
        ps = this.GetComponent<PlayerStats>();

        playerFace = GameObject.FindGameObjectWithTag("PlayerFace");

        fireTimer = 0;
    }

    void Update()
    {
        shoot();
    }

    private void LateUpdate()
    {
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime * 28;
        }
    }

    public void shoot()
    {
        if (fireTimer <= 0)
        {
            Vector2 direction = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = new Vector2(0, 1);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = new Vector2(1, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = new Vector2(-1, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = new Vector2(0, -1);
            }
            createShuriken(direction);
        }
    }

    private void createShuriken(Vector2 direction)
    {
        if(direction == Vector2.zero)
        {
            return;
        }

        fireTimer = ps.getFireRate();

        GameObject shurikenObject = Instantiate(shurikenPrefab);
        shurikenObject.transform.position = playerFace.transform.position;
        shurikenObject.layer = 10;

        Shuriken shuriken = shurikenObject.GetComponent<Shuriken>();
        shuriken.setLifeTimerFromRange(ps.getRange());
        shuriken.setDamage(ps.getDamage());

        Rigidbody2D rb = shurikenObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * ps.getShotSpeed(), ForceMode2D.Impulse);
    }
}
