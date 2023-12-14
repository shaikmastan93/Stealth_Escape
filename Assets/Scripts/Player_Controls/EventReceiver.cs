using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    public PlayerController playerControl;
   [HideInInspector] public bool punchPossible = false;

    public void PunchPossible()
    {
        punchPossible = true;
    }

    public void PunchNotPossible()
    {
        punchPossible = false;
    }
}
