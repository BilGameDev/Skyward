using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    #region Fields
    public float ShakeDuration = 0.5f;

    private Vector3 _originalPos;
    private float _currentShakeDuration;
    private float _shakeMagnitude;

    #endregion

    void Awake()
    {
        // Set the original location
        _originalPos = transform.localPosition;
    }

    void Update()
    {
        // Shakes the camera
        if (_currentShakeDuration > 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeMagnitude;
            _currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = _originalPos;
            _currentShakeDuration = 0f;
        }
    }

    public void TriggerShake(float magnitude)
    {
        _currentShakeDuration = ShakeDuration;
        _shakeMagnitude = magnitude;
    }
}
