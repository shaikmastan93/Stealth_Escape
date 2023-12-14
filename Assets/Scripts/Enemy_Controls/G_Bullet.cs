using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public float damage = 10f; // The amount of damage the bullet deals

    private void Start()
    {
        Destroy(gameObject, 1f);
    }
    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
