using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    //----------------------------------------------Variables--------------------------------------------------
    [SerializeField] float health = 100f; // The current health value of the player
    [SerializeField] float maxHealth = 100f; // The maximum health value of the player
    [SerializeField] Image healthBar; // The health bar UI element
    //private Animator animator;
    [SerializeField] GameObject m_Fail_Screen;
    //Player Health Activation
    [SerializeField] GameObject ObjectToActivate;
    [SerializeField] float activationTime = 2.0f;
    [SerializeField] Animator animator;
    private PlayerGrey PG;
    private EnemyController Pauseshoot;
    public Rigidbody playerRb;
    public Collider playerCollider;
    private RagdolEffect Ragdoll;
    public AudioSource PalyerSource;
    public AudioClip PlayerFailClip;
  
   

    [HideInInspector] public bool playerControlIsActive = false;


    void Start()
    {
        healthBar.fillAmount = health / maxHealth; // Set the initial fill amount of the health bar
        //animator = FindObjectOfType<Animator>();
 
        Invoke("ActivateGameObject", 1f);
        PG = FindObjectOfType<PlayerGrey>();
        Pauseshoot = FindObjectOfType<EnemyController>();
        Ragdoll = GetComponent<RagdolEffect>();
        

    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        HealthBarShows();
        health -= damage; // Reduce health by the amount of damage taken
        healthBar.fillAmount = health / maxHealth; // Update the fill amount of the health bar
        Health_Status();
    }
    void ActivateFailScreen()
    {
        Pauseshoot.StopSound();
        m_Fail_Screen.SetActive(true);
    }
    IEnumerator ActivateForTime()
    {
        ObjectToActivate.SetActive(true);
        yield return new WaitForSeconds(activationTime);
        ObjectToActivate.SetActive(false);
    }
    public void HealthBarShows()
    {
        StartCoroutine(ActivateForTime());
    }
    IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
    public void Health_Status()
    {
        if (health <= 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            animator.SetTrigger("Deads");

            //animator.SetBool("Dead", true);
            PalyerSource.PlayOneShot(PlayerFailClip);
            DeactivatePlayer();
            Ragdoll.ActivateRagdollEffect();
            

            PG.DepartFromThisMortalCoil();

            FindObjectOfType<EnemyController>().StopEnemy();



            Invoke("ActivateFailScreen", 2f);


            
        }
    }
    public void DisableScript()
    {
        GameObject myGameObject = GameObject.Find("MyGameObject");

        // Get a reference to the script component
        PlayerController myScriptComponent = myGameObject.GetComponent<PlayerController>();
    }
    private void DeactivatePlayer()
    {
       
        playerControlIsActive = false;
        playerRb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        playerRb.isKinematic = true;
        playerRb.useGravity = false;
        playerCollider.enabled = false;
    }




}
