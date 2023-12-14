using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets_ : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rb;
    public float bulletLifetime = 0.5f;

    public float damage = 10f; // The amount of damage the bullet deals
 



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Destroy the bullet after a set amount of time
        Invoke("DestroyBullet", bulletLifetime);
        
    }

    void FixedUpdate()
    {
        // Move the bullet forward
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        // Rotate the bullet in the direction it's moving
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}



