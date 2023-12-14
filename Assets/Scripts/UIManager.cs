using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private  Button startButton;
    [SerializeField] private GameObject StartScreen;

    [SerializeField] private GameObject GameWinUi;
    //[SerializeField] private GameObject gameLoseUi;

    private void Awake()
    {
       

        // Activate the game object after 1 second
       
        Time.timeScale = 0f;
        startButton.transform.DOScale(endValue: 1.1f, duration: 0.5f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutFlash);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //private void ShowLoseUI()
    //{

    //    gameLoseUi.SetActive(true);

    //}
    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        PlayerEvents.WinScreen += ShowWinUI;
    }
       

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        PlayerEvents.WinScreen -= ShowWinUI;
        }

    public void StartGame()
    {
        Time.timeScale = 1f;

        // Hides the button
        startButton.gameObject.SetActive(false);
        StartScreen.gameObject.SetActive(false);
    }
    public void ShowWinUI()
    {
        GameWinUi.SetActive(true);
       





    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
