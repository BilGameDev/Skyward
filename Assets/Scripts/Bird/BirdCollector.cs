using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class BirdCollector : MonoBehaviour
{
    #region Fields

    [Inject]
    public GameManager gameManager { get; set; }

    [SerializeField] RectTransform _featherUI;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] BirdAudio _birdAudio;

    #endregion

    void Start()
    {
        AddScore();
    }

    public void OnCollect()
    {
        gameManager._currentScore++;
        AddScore();
        UIScaleUp();
        gameManager.Collector.Play();
        _birdAudio.OnCollectPlay();
    }

    // Plays the easter egg collect effect (This is not being used right now)
    public void OnCollectEasterEgg()
    {
        gameManager.SpecialCollector.Play();
    }

    // Add scores to the current score
    void AddScore()
    {
        _scoreText.text = gameManager._currentScore.ToString();
    }

    // These Tweens make a bounce animation to the feather icon when a feather is collected
    void UIScaleUp()
    {
        _featherUI.ScaleTween(Vector3.one * 1.1f, .1f).SetEase(Ease.EaseInOutCubic).SetOnComplete(() =>
        {
            UIScaleDown();
        });
    }

    void UIScaleDown()
    {
        _featherUI.ScaleTween(Vector3.one, .1f).SetEase(Ease.EaseInOutCubic);
    }
}
