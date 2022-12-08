using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Camera sceneCamera;
    public float moveSpeed;

    public Rigidbody2D rb2d;
    public Weapon weapon;

    private Vector2 moveDirection;

    private Vector2 mousePosition;

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

        if(Input.GetKeyDown(KeyCode.X))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized; 
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    void Move()
    {
        rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
    }
}