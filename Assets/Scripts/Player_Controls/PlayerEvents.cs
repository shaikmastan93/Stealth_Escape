using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Dreamteck.Splines;

public class PlayerEvents : MonoBehaviour
{
    //----------------------------------------------Events--------------------------------------------------
    public static event Action WinScreen;
    //----------------------------------------------Variable--------------------------------------------------
    [SerializeField] Animator anim;
    private bool inTriggerArea = false;
    public AudioSource audioSource;

   
    // Start is called before the first frame update
    void Start()
    {
      // enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            anim.SetBool("Win", true);
            StartCoroutine(WinScreeing());
            audioSource.Play();
            
        }
        


    }
   
   
    IEnumerator WinScreeing()
    {
        yield return new WaitForSeconds(2.0f);
        WinScreen?.Invoke();

    }






}
