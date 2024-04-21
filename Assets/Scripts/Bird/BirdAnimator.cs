using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdAnimator : MonoBehaviour
{
    #region Fields
    [Inject]
    public BirdMovement birdMovement { get; set; }

    [SerializeField] float _tiltAmount; // Ampunt to Tilt
    [SerializeField] Animator _animator; // Animator component

    #endregion


    void Update()
    {
        // Sets the bird animations based on movement
        _animator.SetFloat("X", -birdMovement.move.z * _tiltAmount);
    }
}
