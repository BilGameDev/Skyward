using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrackMovement : MonoBehaviour
{
    [HideInInspector] public ObjectPooler objectPooler;
    [SerializeField] EasterEggHandler easterEggHandler;
    private int trackNumber;

    public int TrackNumber
    {
        get { return trackNumber; }
        set
        {
            if (trackNumber != value)
            {
                trackNumber = value;
                //Checks if the easter egg should be spawned.
                easterEggHandler.CheckEasterEgg(trackNumber);
            }
        }
    }

    void Update()
    {
        //Moves the track tiles according to moving speed
        if (!objectPooler.gameManager.GameOver)
            transform.Translate(objectPooler.moveDirection * objectPooler.movingSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Destroys the tile after it goes past the destroy zone
        if (transform.position.x < -objectPooler.destoryZone)
            objectPooler.DestroyChunk(this);
    }
}
