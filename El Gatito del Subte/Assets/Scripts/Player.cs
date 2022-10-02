using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseClass
{
    public int movementSpeed;
    void FixedUpdate()
    {
        Vector2 movementDirection = Vector2.zero;
        if(!globalScript.isPlayingIntro)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movementDirection += Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementDirection += Vector2.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementDirection += Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementDirection += Vector2.right;
            }
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + movementDirection.normalized * movementSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Train"))
        {
            globalScript.gameOver();
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            globalScript.increaseScore(1);
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("TunnelLimit"))
        {
            globalScript.switchCurrentTimer(col.gameObject.name);
        }
    }
}