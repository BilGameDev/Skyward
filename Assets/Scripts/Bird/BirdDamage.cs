using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdDamage : MonoBehaviour
{
    // Injects the game manager (Dependecy Injection)
    [Inject]
    public GameManager gameManager { get; set; }
    [SerializeField] SkinnedMeshRenderer meshRenderer;
    [SerializeField] BirdAudio birdAudio;

    // This method is called on death
    public void OnDie()
    {
        birdAudio.OnDiePlay();
        gameManager.poof.Play();
        meshRenderer.enabled = false;
        gameManager.cameraShaker.TriggerShake(0.2f);
    }
}
