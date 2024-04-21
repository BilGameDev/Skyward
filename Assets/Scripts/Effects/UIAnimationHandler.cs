using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIAnimationHandler : MonoBehaviour
{
    #region Fields

    //Injects the game manager (Dependecy Injection)
    [Inject]
    public GameManager gameManager { get; set; }

    [Header("UI")]
    [SerializeField] public RectTransform MainCanvas;
    [SerializeField] public CanvasGroup BlackFadeGroup;
    [SerializeField] public CanvasGroup GameOverGroup;
    [SerializeField] public RectTransform GameOverPanel;

    [SerializeField] public RectTransform FeatherUI;
    [SerializeField] TextMeshProUGUI _gameOverScore;

    [Header("Audio")]
    [SerializeField] AudioSource _tapSource;
    [SerializeField] AudioClip _tapClip;

    private int _finalScore;

    [Header("Score Counter")]
    public float Duration = 5f; // The time it takes to log up to the target number
    private int _currentNumber = 0; // Current number being logged

    #endregion


    void Start()
    {
        // Subscribe to the gameover event 
        gameManager.OnGameOver += GameOver;
    }

    void GameOver()
    {
        _finalScore = gameManager._currentScore;
        GameOverGroup.FadeIn(1);
        //Tweens in the gameover panel
        GameOverPanel.MoveUI(new Vector2(.5f, .3f), MainCanvas, 1.5f, Platinio.UI.PivotPreset.LowerCenter).SetEase(Ease.EaseOutBounce).SetOnComplete(() => { DisplayScore(); });
    }

    void DisplayScore()
    {
        //Tweens in the final score graphic
        FeatherUI.GetComponent<CanvasGroup>().FadeIn(.2f);
        FeatherUI.ScaleTween(Vector3.one, .4f).SetEase(Ease.EaseOutExpo).SetOnComplete(() => { StartCoroutine(LogNumbers()); });
    }


    //This method is used to animate the score count
    IEnumerator LogNumbers()
    {
        while (_currentNumber <= _finalScore)
        {
            _gameOverScore.text = _currentNumber.ToString();
            _currentNumber++;
            _tapSource.PlayOneShot(_tapClip);

            yield return new WaitForSeconds(Duration / _finalScore);
        }

        gameManager.RestartLevelButton.gameObject.SetActive(true);

    }
}
