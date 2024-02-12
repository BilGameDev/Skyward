using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] public GameObject endZoneCamera;
    [SerializeField] public GameObject transitionCamera;
    [SerializeField] public CinemachineVirtualCamera gameCamera;
    [SerializeField] public CameraShaker cameraShaker;

    [Header("Particle System")]
    [SerializeField] public ParticleSystem collector;
    [SerializeField] public ParticleSystem specialCollector;
    [SerializeField] public ParticleSystem poof;

    [Header("UI")]
    [SerializeField] public Button restartLevel;
    [SerializeField] public Button mainMenu;
    public event Action OnGameOver;

    [Header("Audio")]
    [SerializeField] AudioSource gameSource;

    public int currentScore;


    public bool GameStarted;
    public bool EasterEggCollected;

    private bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            if (gameOver != value)
            {
                gameOver = value;
                if (value == true) GameEnd();
            }
        }
    }

    void Start()
    {
        //Add listeners to the buttons
        restartLevel.onClick.AddListener(() => { RestartLevel(); });
        mainMenu.onClick.AddListener(() => { MainMenu(); });
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
        gameSource.volume = 0.1f;
        OnGameOver?.Invoke();
    }
}
