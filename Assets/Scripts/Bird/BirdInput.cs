using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdInput : MonoBehaviour
{
    #region Fields

    [HideInInspector] public Vector2 TouchDeltaPosition;
    public LayerMask EasterEggLayer;

    private float _lastTapTime = 0f;
    private float _tapSpeed = .2f; // Time in seconds for a double tap

    #endregion


    // Injects the game manager and birdMovement (Dependecy Injection)
    [Inject]
    public BirdMovement birdMovement { get; set; }

    [Inject]
    public GameManager gameManager { get; set; }

    void Update()
    {
        if (!gameManager.GameOver && gameManager.GameStarted)
            HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Double-tap detection
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - _lastTapTime < _tapSpeed)
                {
                    // Detected a double tap
                    birdMovement.SetReset(true);
                }
                _lastTapTime = Time.time;
            }

            // Check if it's a tap
            if (touch.phase == TouchPhase.Ended)
            {
                // Convert touch position to world space
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the touch hits an object on the selectable layers
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, EasterEggLayer))
                {
                    // Handle object selection
                    GameObject easterEgg = hit.collider.gameObject;
                    easterEgg.GetComponent<EasterEgg>().Acquire();

                }
            }

            if (!birdMovement.GetReset())
            {
                TouchDeltaPosition = touch.deltaPosition;

                birdMovement.HandleMovement(TouchDeltaPosition);
            }
        }
    }
}
