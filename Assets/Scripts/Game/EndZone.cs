using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EndZone : MonoBehaviour
{
    [Inject]
    public GameManager gameManager { get; set; }

    //This is used to end the level, but I am not using this right now
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.endZoneCamera.SetActive(true);
            gameManager.GameOver = true;
        }
    }
}
