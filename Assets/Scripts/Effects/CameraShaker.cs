using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
   public float shakeDuration = 0.5f;

    private Vector3 originalPos;
    private float currentShakeDuration;
    private float shakeMagnitude;

    void Awake()
    {
        // Set the original location
        originalPos = transform.localPosition;
    }

    void Update()
    {
        // Shakes the camera
        if (currentShakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeMagnitude;
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPos;
            currentShakeDuration = 0f;
        }
    }

    public void TriggerShake(float magnitude)
    {
        currentShakeDuration = shakeDuration;
        shakeMagnitude = magnitude;
    }
}
