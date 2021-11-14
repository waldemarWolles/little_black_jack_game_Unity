using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private GameObject DeathMenu;
    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody2D rb;

    private GameObject[] enemies;


    Vector2 movement;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        for (var i = 0; i < enemies.Length; i++)
        {
            if ((playerPos.x - enemies[i].transform.position.x > 0 ? playerPos.x - enemies[i].transform.position.x < 1.5 : playerPos.x - enemies[i].transform.position.x > -1.5) && (playerPos.y - enemies[i].transform.position.y > 0 ? playerPos.y - enemies[i].transform.position.y < 1.5 : playerPos.y - enemies[i].transform.position.y > -1.5))
            {
                DeathMenu.SetActive(true);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "TouchIndicator")
        {
            GameOver();
        }

    }

    public void GameOver()
    {
        DeathMenu.SetActive(true);
        Destroy(gameObject);
    }
}
