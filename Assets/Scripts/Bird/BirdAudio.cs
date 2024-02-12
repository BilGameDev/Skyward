using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdAudio : MonoBehaviour
{
    [Inject]
    public GameManager gameManager { get; set; }
    [SerializeField] AudioSource collectSource;
    [SerializeField] AudioSource flapsSource;
    [SerializeField] AudioClip collectClip;
    [SerializeField] AudioClip dieClip;

    void Start()
    {
        gameManager.OnGameOver += GameEnd;
    }

    // Plays the collect sound
    public void OnCollectPlay()
    {
        collectSource.PlayOneShot(collectClip);
    }

    // Plays on death
    public void OnDiePlay()
    {
        collectSource.PlayOneShot(dieClip);
    }

    // Stops the flaps sound effects
    void GameEnd()
    {
        flapsSource.Stop();
    }
}
