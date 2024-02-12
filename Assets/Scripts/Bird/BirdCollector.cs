using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class BirdCollector : MonoBehaviour
{
    [Inject]
    public GameManager gameManager { get; set; }
    [SerializeField] RectTransform featherUI;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] BirdAudio birdAudio;

    void Start()
    {
        AddScore();
    }

    public void OnCollect()
    {
        gameManager.currentScore++;
        AddScore();
        UIScaleUp();
        gameManager.collector.Play();
        birdAudio.OnCollectPlay();
    }

    // Plays the easter egg collect effect (This is not being used right now)
    public void OnCollectEasterEgg()
    {
        gameManager.specialCollector.Play();
    }

    // Add scores to the current score
    void AddScore()
    {
        scoreText.text = gameManager.currentScore.ToString();
    }

    // These Tweens make a bounce animation to the feather icon when a feather is collected
    void UIScaleUp()
    {
        featherUI.ScaleTween(Vector3.one * 1.1f, .1f).SetEase(Ease.EaseInOutCubic).SetOnComplete(() =>
        {
            UIScaleDown();
        });
    }

    void UIScaleDown()
    {
        featherUI.ScaleTween(Vector3.one, .1f).SetEase(Ease.EaseInOutCubic);
    }
}
