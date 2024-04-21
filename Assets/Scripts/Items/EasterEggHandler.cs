using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggHandler : MonoBehaviour
{
    [SerializeField] GameObject EasterEgg;
    [SerializeField] int spawnTrack = 20;
    [SerializeField] TrackMovement trackMovement;

    public void CheckEasterEgg(int trackNumber)
    {
        if (trackNumber == spawnTrack && !trackMovement.Pooler.gameManager.EasterEggCollected)
        {
            EasterEgg.SetActive(true);
            trackMovement.Pooler.gameManager.EasterEggCollected = true;
        }

    }
}
