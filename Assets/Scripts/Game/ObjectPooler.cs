using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPooler : MonoBehaviour
{
    #region Fields

    //Object pooling helps with performance by reusing assets instead of instantiating and destroying.
    public GameObject[] Tracks;
    public int InitialSpawnCount = 5;
    public float DestoryZone = 300;

    [HideInInspector]
    public Vector3 MoveDirection = new Vector3(0, 0, -1);
    public float MovingSpeed = 1;


    public float TrackSize = 60;
    GameObject _lastTrack;

    [Inject]
    public GameManager gameManager { get; set; }

    public int TrackCount = 0;

    #endregion

    void Awake()
    {
        // Instantiates a starting pool
        Tracks[0].transform.parent.gameObject.SetActive(false);
        InitialSpawnCount = InitialSpawnCount > Tracks.Length ? InitialSpawnCount : Tracks.Length;

        int chunkIndex = 0;
        for (int i = 0; i < InitialSpawnCount; i++)
        {
            GameObject track = Instantiate(Tracks[chunkIndex]);

            track.SetActive(true);
            TrackMovement trackMovement = track.GetComponent<TrackMovement>();
            SetTrackNumber(trackMovement);
            trackMovement.Pooler = this;

            track.transform.localPosition = new Vector3(i * TrackSize, 0, transform.position.z);
            MoveDirection = new Vector3(-1, 0, 0);


            _lastTrack = track;

            if (++chunkIndex >= Tracks.Length)
                chunkIndex = 0;
        }
    }

    public void DestroyChunk(TrackMovement thisTrack)
    {
        //This method reuses the tracks when they are "destroyed"
        Vector3 newPos = _lastTrack.transform.position;

        newPos.x += TrackSize;

        SetTrackNumber(thisTrack);
        thisTrack.gameObject.GetComponent<ObstacleSpawner>().Spawn();
        _lastTrack = thisTrack.gameObject;
        _lastTrack.transform.position = newPos;
    }

    void SetTrackNumber(TrackMovement track)
    {
        //Sets the track number
        TrackCount++;
        track.TrackNumber = TrackCount;
    }
}
