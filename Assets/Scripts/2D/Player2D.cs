using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] float moveSpeed = 2f, jumpForce = 7f, knockbackStrength = 1f;
    Rigidbody2D rb;
    bool isGrounded, isGameOver;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = 100;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            Move();
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            TakeDamage(other);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(Collision2D other)
    {
        Vector2 knockbackDir = transform.position - other.transform.position;
        knockbackDir = knockbackDir.normalized * knockbackStrength;
        rb.AddForce(knockbackDir, ForceMode2D.Impulse);
        currentHealth -= 50;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            isGameOver = true;
            ArcadeManager.Instance.GameOver();
        }
    }
}
