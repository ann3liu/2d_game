using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb2d;

    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        
        ProcessInputs();
    }

    void FixedUpdate()
    {

        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY); //come back to this
    }

    void Move()
    {
        rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}