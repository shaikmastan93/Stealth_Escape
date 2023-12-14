using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
   
    private bool inTriggerArea = false;
    public PlayerAnimation playerAnimation;
    public PlayerController playerControl;
    public bool animationEnabled;
    public EventReceiver eventReceiver;
    private bool isPunching = false;
    private EnemyController enemys_;
    [SerializeField]private DeactivateEnemy deactivateenemy;

    public AudioSource PalyerSource_;
    public AudioClip PlayerKnifeClip;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PalyerSource_.PlayOneShot(PlayerKnifeClip);
            EnemyController enemcontroller =other. GetComponent<EnemyController>();
            isPunching = true;
            inTriggerArea = true;
             playerAnimation.MakePunch();
            enemys_ = enemcontroller;
            deactivateenemy.SetEnemy(enemcontroller);
          Debug.Log("Kottesey");
          
        }
    }
    void OnTriggerExit(Collider other)
    {
        isPunching = false;
        inTriggerArea = false;
        playerAnimation.NotMakePunch();
        Debug.Log("Stop it punch");
    }

    
  
    public void DeactivateEnemy()
    {
        enemys_.DeactivateCurrentEnemy();
    }
  

    
}
