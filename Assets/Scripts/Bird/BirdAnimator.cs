using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdAnimator : MonoBehaviour
{
    [SerializeField] float tiltAmount;
    [SerializeField] Animator animator;

    [Inject]
    public BirdMovement birdMovement { get; set; }

    void Update()
    {
        // Sets the bird animations based on movement
        animator.SetFloat("X", -birdMovement.move.z * tiltAmount);
    }
}
