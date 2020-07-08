using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    private Rigidbody2D rb;
    private HealthSystem hs;

    //movement
    private float h;
    private float v;
    public float speed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        hs = this.GetComponent<HealthSystem>();

        hs.setHealth(100);
        hs.setHealthMax(100);
        hs.setHealthDisplay();
    }

    private void Update()
    {
        getWASD();
    }

    private void FixedUpdate()
    {
        playerMovement(h, v);
    }

    private void getWASD()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void playerMovement(float h, float v)
    {
        Vector2 moveX = rb.transform.right * h;
        Vector2 moveY = rb.transform.up * v;
        Vector2 movement = moveX + moveY;

        movement = movement * speed * Time.deltaTime;

        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "Floor")
        {
            //Debug.Log(collision.collider.tag);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Door"))
        {
            //Debug.Log("Door");
            //change room
        }
    }
}
