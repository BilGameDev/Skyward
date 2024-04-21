using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields

    [Header("Cameras")]
    [SerializeField] public GameObject EndZoneCamera;
    [SerializeField] public GameObject TransitionCamera;
    [SerializeField] public CinemachineVirtualCamera GameCamera;
    [SerializeField] public CameraShaker CameraShaker;

    [Header("Particle System")]
    [SerializeField] public ParticleSystem Collector;
    [SerializeField] public ParticleSystem SpecialCollector;
    [SerializeField] public ParticleSystem Poof;

    [Header("UI")]
    [SerializeField] public Button RestartLevelButton;
    [SerializeField] Button _mainMenuButton;
    public event Action OnGameOver;

    [Header("Audio")]
    [SerializeField] AudioSource _gameSource;

    public int _currentScore;


    public bool GameStarted;
    public bool EasterEggCollected;

    private bool _gameOver;

    public bool GameOver
    {
        get { return _gameOver; }
        set
        {
            if (_gameOver != value)
            {
                _gameOver = value;
                if (value == true) GameEnd();
            }
        }
    }

    #endregion

    void Start()
    {
        //Add listeners to the buttons
        RestartLevelButton.onClick.AddListener(() => { RestartLevel(); });
        _mainMenuButton.onClick.AddListener(() => { MainMenu(); });
    }

    void RestartLevel()
    {
        //Restart the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void MainMenu()
    {
        //Go to menu scene
        SceneManager.LoadScene(0);
    }

    void GameEnd()
    {
        _gameSource.volume = 0.1f;
        OnGameOver?.Invoke();
    }
}
