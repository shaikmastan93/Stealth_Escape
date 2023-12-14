using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //----------------------------------------------Variables--------------------------------------------------
    [SerializeField] Joystick joystick;
    [SerializeField] Animator animator;



    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if (vertical !=0 && horizontal !=0)
        {
            animator.SetBool("isRunning", true);
           
        }
        else 
        {
            animator.SetBool("isRunning", false);
            
        }
    }
}
