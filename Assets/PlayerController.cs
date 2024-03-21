using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public Transform shootingPoint;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    void Update()
    {
        if (isLocalPlayer)
        {
            ProcessInputs();
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 shootingDirection = (mousePosition - rb.position).normalized; 
                CmdShoot(shootingDirection); 
            }
        }
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Move();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    [Command]
    void CmdShoot(Vector2 shootingDirection)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        NetworkServer.Spawn(projectile);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        
        projectileRb.velocity = shootingDirection * projectileSpeed;
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg - 90f;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        
    }
}
