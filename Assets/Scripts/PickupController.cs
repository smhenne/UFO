//Sam Hennessey 09/22/24
//Script for the pickup object to control the random movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
     private Rigidbody2D rb;
     public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)); // Random movement
        rb.velocity = movement * speed;
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y); // Reverse velocity on wall collision
        }
    }
}
