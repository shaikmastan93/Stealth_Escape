using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    //----------------------------------------------Variables--------------------------------------------------
    [SerializeField] float speed;             // The speed of the player movement
    [SerializeField] Joystick joystick;       // Reference to the joystick
    [SerializeField] Animator animator;       // Reference to the Animator component

    private Rigidbody rb;           // Reference to the Rigidbody component
    private Vector3 movement;       // The movement vector of the player

   
    // ----------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        // Get the horizontal and vertical input from the joystick
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        // Set the movement vector based on the input and speed
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            //rb.velocity = new Vector3(-joystick.Horizontal*5.0f, 0, -joystick.Vertical*5.0f);
            rb.velocity = new Vector3(movement.x * 50.0f, 0, movement.z * 50.0f);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }

    }

    
  
  
}   
