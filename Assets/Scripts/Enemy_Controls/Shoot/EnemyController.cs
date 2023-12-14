using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    //----------------------------------------------Variables--------------------------------------------------

    [SerializeField] SplineFollower splineFollower;
    [SerializeField]float fireRate = 2.0f;
    [SerializeField] GameObject player;
   [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject particleEffect;
    
    private bool isFiring = false;
    [SerializeField]Transform FirePos;
    public Animator Enemy_Anim;
    public EnemyAnimation enemyAnimation;

    [HideInInspector]
    public bool enemyDeactivated = false;
    public Rigidbody enemyRb;
    public Collider enemyCollider;
    public AudioSource audioSource;
    public ParticleSystem shootParticle;
    public Transform ShotParticlePos;
    [SerializeField] GameObject BloodparticleEffect;
    [SerializeField] Transform BloodPos;

    [SerializeField]private float _fadeStart { get; set; }

   
    void Start()
    {
        Enemy_Anim = GetComponentInChildren<Animator>();
       
    }

  

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            GameObject projectile = Instantiate(projectilePrefab, FirePos.position, rotation);
            


            // Set up the projectile's script to move towards the player

            yield return new WaitForSeconds(fireRate);
        }
    }

  

    public void StartFiring()
    {
        splineFollower.follow = false;
      
        isFiring = true;
        StartSound();
        Enemy_Anim.SetBool("Fire", true);
        StartCoroutine(FireCoroutine());
        Instantiate(shootParticle, ShotParticlePos.position, Quaternion.identity);
    }

    public void StopFiring()
    {
        isFiring = false;
        Enemy_Anim.SetBool("Fire", false);
        splineFollower.follow = true;
    }
    public void PauseFiring()
    {
        isFiring = false;
        splineFollower.follow = false;
    }
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayDeathAnimation());
           
        }
    }
    IEnumerator PlayDeathAnimation()
    {
        yield return new WaitForSeconds(1f); // wait for 1 second
        
        isFiring = false;
        Enemy_Anim.SetBool("Dead", true);
        splineFollower.enabled = false;
     

    }
    public void DeactivateCurrentEnemy()
    {
        Instantiate(BloodparticleEffect, BloodPos.position, Quaternion.identity);
        Enemy_Anim.SetBool("Dead", true);
        StopFieldofViws_();
        isFiring = false;
        splineFollower.enabled = false;
        enemyDeactivated = true;
        enemyRb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        enemyRb.isKinematic = true;
        enemyRb.useGravity = false;
        enemyCollider.enabled = false;
    }
    public void StopEnemy()
    {
        StopFieldofViws_();

        isFiring = false;
        splineFollower.enabled = false;

    }
    public void StopFieldofViws_()
    {
        var scriptComponent = gameObject.GetComponent<FieldOfView>();
        Destroy(scriptComponent);
    }
    public void StartSound()
    {
        audioSource.Play();
    }
    public void StopSound()
    {
        audioSource.Stop();

    }
    







}
