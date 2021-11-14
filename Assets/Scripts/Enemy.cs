using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float chaseSpeed;
    Transform player;
    [HideInInspector] private bool mustPatrol;

    Rigidbody2D rb;
    public Collider2D bodyCollider;
    public LayerMask wallsLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            mustPatrol = false;
        }
        else
        {
            mustPatrol = true;
        }
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
        else if (!mustPatrol)
        {
            Chase();
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }


    private void Patrol()
    {
        if (bodyCollider.IsTouchingLayers(wallsLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }


}
