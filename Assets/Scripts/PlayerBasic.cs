using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{
    private Rigidbody2D rb;
    private HealthSystem hs;
    private PlayerStats ps;
    private GameObject playerFace;

    //movement
    private float h;
    private float v;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        hs = this.GetComponent<HealthSystem>();
        ps = this.GetComponent<PlayerStats>();
        playerFace = GameObject.FindGameObjectWithTag("PlayerFace");

        //hs.setHealth(100);
        //hs.setHealthMax(100);
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

        movement = movement * ps.getSpeed() * 6.5f * Time.deltaTime;

        rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + movement);
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
