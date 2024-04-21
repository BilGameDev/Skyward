using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Fields

    [Header("Game Settings")]
    [SerializeField] GameSettings _gameSettings;
    [SerializeField] AudioSource _mainMenuSource;

    [Header("UI")]
    [SerializeField] Button _playGameButton;
    [SerializeField] Button _colorPickerButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] BirdColor _birdColorButton;
    [SerializeField] Button _soundButton;
    [SerializeField] TextMeshProUGUI _soundText;

    [Header("Bird Animation")]
    [SerializeField] Animator _birdAnimator;
    [SerializeField] LayerMask _birdLayer;

    private bool _audioMuted = false;

    #endregion

    void Start()
    {

        Application.targetFrameRate = 60;

        _audioMuted = !_gameSettings.SoundOn;

        SetAudio();

        _playGameButton.onClick.AddListener(() =>
        {
            PlayGame();
        });

        _colorPickerButton.onClick.AddListener(() =>
        {
            _birdColorButton.RandomizeBird();
        });

        _soundButton.onClick.AddListener(() =>
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
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, _birdLayer))
                {
                    // Handle object selection
                    _birdAnimator.SetTrigger("Tap");

                }
            }
        }
    }

    void ToggleMute()
    {
        _audioMuted = !_audioMuted;
        _gameSettings.SoundOn = !_audioMuted;
        SetAudio();
    }

    void SetAudio()
    {
        _mainMenuSource.mute = _audioMuted;
        _soundText.text = _audioMuted ? "Sound : Off" : "Sound : On";
    }


}
