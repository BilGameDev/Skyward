using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BirdDamage : MonoBehaviour
{
    #region Fields

    // Injects the game manager (Dependecy Injection)
    [Inject]
    public GameManager gameManager { get; set; }

    [SerializeField] SkinnedMeshRenderer _meshRenderer;
    [SerializeField] BirdAudio _birdAudio;

    #endregion

    // This method is called on death
    public void OnDie()
    {
        _birdAudio.OnDiePlay();
        gameManager.Poof.Play();
        _meshRenderer.enabled = false;
        gameManager.CameraShaker.TriggerShake(0.2f);
    }
}
