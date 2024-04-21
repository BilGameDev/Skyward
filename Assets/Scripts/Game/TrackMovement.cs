using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TrackMovement : MonoBehaviour
{
    #region Fields

    [HideInInspector] public ObjectPooler Pooler;
    [SerializeField] EasterEggHandler _easterEggHandler;
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
                _easterEggHandler.CheckEasterEgg(trackNumber);
            }
        }
    }

    #endregion

    void Update()
    {
        //Moves the track tiles according to moving speed
        if (!Pooler.gameManager.GameOver)
            transform.Translate(Pooler.MoveDirection * Pooler.MovingSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //Destroys the tile after it goes past the destroy zone
        if (transform.position.x < -Pooler.DestoryZone)
            Pooler.DestroyChunk(this);
    }
}
