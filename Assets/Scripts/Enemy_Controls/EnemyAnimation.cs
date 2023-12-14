using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
   public Animator enemyAnimator;
    private bool enemyConditionStay = true;
    // Start is called before the first frame update
    public void DeactivateAnimator()
    {
        enemyAnimator.enabled = false;
    }
}
