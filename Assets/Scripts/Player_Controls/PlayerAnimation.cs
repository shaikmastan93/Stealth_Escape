using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    public void MakePunch()
    {
        playerAnimator.SetBool("Punch", true);
    }
    public void NotMakePunch()
    {
        playerAnimator.SetBool("Punch", false);
    }
}
