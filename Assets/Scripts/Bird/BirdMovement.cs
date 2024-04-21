using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdMovement : MonoBehaviour
{
    #region Fields

    public float Speed = 5.0f; // Adjust speed as needed for gameplay feel
    public float resetSpeed = 1.0f; // Speed at which to reset position smoothly
    [HideInInspector] public Vector3 move;

    private bool isResetting = false;
    private Vector2 _movementBounds = new Vector2(1, 2); // Bounds for movement on X and Y

    #endregion

    //During testing, the bird movement was slower on the editor so i set a larger value
    void Awake()
    {
#if UNITY_EDITOR
        Speed = 0.5f;
#endif
    }

    void Update()
    {
        if (isResetting)
        {
            // Smoothly interpolate position back to (0, 0, 0)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.down, resetSpeed * Time.deltaTime);
            // Check if reset is complete
            if (transform.localPosition == Vector3.down)
            {
                isResetting = false; // Stop resetting
            }
        }

    }

    public void HandleMovement(Vector2 touchDeltaPosition)
    {

        // Adjusting the touch sensitivity
        Vector3 movementDirection = new Vector3(0, touchDeltaPosition.y, -touchDeltaPosition.x);
        move = movementDirection * Speed * Time.deltaTime;

        // Only move if there's significant input to avoid overly sensitive movement
        transform.Translate(move, Space.World);

        // Clamp the bird's position to ensure it stays within the specified bounds
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Clamp(transform.localPosition.y, -_movementBounds.y, _movementBounds.y),
            Mathf.Clamp(transform.localPosition.z, -_movementBounds.x, _movementBounds.x)); // Keep the Z position unchanged
    }

    public void SetReset(bool reset)
    {
        isResetting = reset;
    }

    public bool GetReset()
    {
        return isResetting;
    }
}
