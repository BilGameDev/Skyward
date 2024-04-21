using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    [SerializeField] TrackMovement trackMovement;
    [SerializeField] AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trackMovement.Pooler.gameManager.GameOver = true;
            other.GetComponent<BirdDamage>().OnDie();
            audioSource.Stop();
        }
    }
}
