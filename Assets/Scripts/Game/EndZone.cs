using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EndZone : MonoBehaviour
{
    #region Fields

    [Inject]
    public GameManager gameManager { get; set; }

    #endregion

    //This is used to end the level, but I am not using this right now
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.EndZoneCamera.SetActive(true);
            gameManager.GameOver = true;
        }
    }
}
