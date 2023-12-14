using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrey : MonoBehaviour
{
    public Renderer playerRenderer; // This is a reference to the player's Renderer component
    public Color grayColor;

    public void DepartFromThisMortalCoil()
    {
        playerRenderer.material.color = grayColor; // Set the color of the player's material to grayColor
    }
        

}
 

