using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIAnimationHandler : MonoBehaviour
{
    //Injects the game manager (Dependecy Injection)
    [Inject]
    public GameManager gameManager { get; set; }

    [Header("UI")]
    [SerializeField] public RectTransform mainCanvas;
    [SerializeField] public CanvasGroup blackFadeGroup;
    [SerializeField] public CanvasGroup gameOverGroup;
    [SerializeField] public RectTransform gameOverPanel;

    [SerializeField] public RectTransform featherUI;
    [SerializeField] TextMeshProUGUI gameOverScore;
    [Header("Audio")]
    [SerializeField] AudioSource tapSource;
    [SerializeField] AudioClip tapClip;

    private int finalScore;

    [Header("Score Counter")]
    public float duration = 5f; // The time it takes to log up to the target number
    private int currentNumber = 0; // Current number being logged


    void Start()
    {
        // Subscribe to the gameover 
        gameManager.OnGameOver += GameOver;
    }

    void GameOver()
    {
        finalScore = gameManager.currentScore;
        gameOverGroup.FadeIn(1);
        //Tweens in the gameover panel
        gameOverPanel.MoveUI(new Vector2(.5f, .3f), mainCanvas, 1.5f, Platinio.UI.PivotPreset.LowerCenter).SetEase(Ease.EaseOutBounce).SetOnComplete(() => { DisplayScore(); });
    }

    void DisplayScore()
    {
        //Tweens in the final score graphic
        featherUI.GetComponent<CanvasGroup>().FadeIn(.2f);
        featherUI.ScaleTween(Vector3.one, .4f).SetEase(Ease.EaseOutExpo).SetOnComplete(() => { StartCoroutine(LogNumbers()); });
    }


    //This method is used to animate the score count
    IEnumerator LogNumbers()
    {
        while (currentNumber <= finalScore)
        {
            gameOverScore.text = currentNumber.ToString();
            currentNumber++;
            tapSource.PlayOneShot(tapClip);

            yield return new WaitForSeconds(duration / finalScore);
        }

        gameManager.restartLevel.gameObject.SetActive(true);

    }
}
