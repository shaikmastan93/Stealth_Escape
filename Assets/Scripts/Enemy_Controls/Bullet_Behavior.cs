using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    //----------------------------------------------Variables--------------------------------------------------
    [SerializeField] float speed = 10f; // speed of the bullet
    private Rigidbody rb; // rigidbody component of the bullet
    [SerializeField] float damage = 10f; // The amount of damage the bullet deals
    [SerializeField] float bulletLifetime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the rigidbody component
        Invoke("DestroyBullet", bulletLifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       //rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * speed;
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
