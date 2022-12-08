using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bullet;

    public Transform firePoint;

    public float fireForce;

    private Vector2 moveDirection;

    private Vector2 mousePosition;

    public Camera sceneCamera;
    public float moveSpeed;

    public Rigidbody2D rb2d;
    public Weapon weapon;

     public void Fire()
    {

        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        
        ProcessInputs();
    }

    void FixedUpdate()
    {

        Rotate();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    void Rotate()
    {
        rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle; 
    }
}
