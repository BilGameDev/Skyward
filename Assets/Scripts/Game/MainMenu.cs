using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] GameSettings gameSettings;
    [SerializeField] AudioSource mainMenuSource;

    [Header("UI")]
    [SerializeField] Button playGame;
    [SerializeField] Button colorPicker;
    [SerializeField] Button settings;
    [SerializeField] BirdColor birdColor;
    [SerializeField] Button soundButton;
    [SerializeField] TextMeshProUGUI soundText;

    [Header("Bird Animation")]
    [SerializeField] Animator birdAnimator;
    [SerializeField] LayerMask birdLayer;

    private bool audioMuted = false;
    void Start()
    {

        Application.targetFrameRate = 60;

        audioMuted = !gameSettings.soundOn;

        SetAudio();

        playGame.onClick.AddListener(() =>
        {
            PlayGame();
        });

        colorPicker.onClick.AddListener(() =>
        {
            birdColor.RandomizeBird();
        });

        soundButton.onClick.AddListener(() =>
        {
            ToggleMute();
        });
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position to world space
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the touch hits an object on the selectable layers
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, birdLayer))
                {
                    // Handle object selection
                    birdAnimator.SetTrigger("Tap");

                }
            }
        }
    }

    void ToggleMute()
    {
        audioMuted = !audioMuted;
        gameSettings.soundOn = !audioMuted;
        SetAudio();
    }

    void SetAudio()
    {
        mainMenuSource.mute = audioMuted;
        soundText.text = audioMuted ? "Sound : Off" : "Sound : On";
    }


}
