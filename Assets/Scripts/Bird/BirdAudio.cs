using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdAudio : MonoBehaviour
{
    #region Fields

    [Inject]
    public GameManager Manager { get; set; } // Injection of the game manager.
    
    [SerializeField] AudioSource _collectSource; // Audio source for collection.
    [SerializeField] AudioSource _flapsSource;  // Audio source for flaps.
    [SerializeField] AudioClip _collectClip; // Audio clip for collection.
    [SerializeField] AudioClip _dieClip; // Audio clip for death.

    #endregion

    // Subscribe to the game end event
    void Start()
    {
        Manager.OnGameOver += GameEnd;
    }

    // Plays the collect sound
    public void OnCollectPlay()
    {
        _collectSource.PlayOneShot(_collectClip);
    }

    // Plays on death
    public void OnDiePlay()
    {
        _collectSource.PlayOneShot(_dieClip);
    }

    // Stops the flaps sound effects
    void GameEnd()
    {
        _flapsSource.Stop();
    }
}
