using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdInput : MonoBehaviour
{
    private float lastTapTime = 0f;
    private float tapSpeed = .2f; // Time in seconds for a double tap
    [HideInInspector] public Vector2 touchDeltaPosition;
    public LayerMask easterEggLayer;
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
                if (Time.time - lastTapTime < tapSpeed)
                {
                    // Detected a double tap
                    birdMovement.SetReset(true);
                }
                lastTapTime = Time.time;
            }

            // Check if it's a tap
            if (touch.phase == TouchPhase.Ended)
            {
                // Convert touch position to world space
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the touch hits an object on the selectable layers
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, easterEggLayer))
                {
                    // Handle object selection
                    GameObject easterEgg = hit.collider.gameObject;
                    easterEgg.GetComponent<EasterEgg>().Acquire();
                    
                }
            }

            if (!birdMovement.GetReset())
            {
                touchDeltaPosition = touch.deltaPosition;

                birdMovement.HandleMovement(touchDeltaPosition);
            }
        }
    }
}
