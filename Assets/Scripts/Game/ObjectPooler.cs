using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPooler : MonoBehaviour
{
    //Object pooling helps with performance by reusing assets instead of instantiating and destroying.
    public GameObject[] tracks;
    public int initialSpawnCount = 5;
    public float destoryZone = 300;

    [HideInInspector]
    public Vector3 moveDirection = new Vector3(0, 0, -1);
    public float movingSpeed = 1;


    public float trackSize = 60;
    GameObject lastTrack;

    [Inject]
    public GameManager gameManager { get; set; }

    public int trackCount = 0;

    void Awake()
    {   
        // Instantiates a starting pool
        tracks[0].transform.parent.gameObject.SetActive(false);
        initialSpawnCount = initialSpawnCount > tracks.Length ? initialSpawnCount : tracks.Length;

        int chunkIndex = 0;
        for (int i = 0; i < initialSpawnCount; i++)
        {
            GameObject track = Instantiate(tracks[chunkIndex]);

            track.SetActive(true);
            TrackMovement trackMovement = track.GetComponent<TrackMovement>();
            SetTrackNumber(trackMovement);
            trackMovement.objectPooler = this;

            track.transform.localPosition = new Vector3(i * trackSize, 0, transform.position.z);
            moveDirection = new Vector3(-1, 0, 0);


            lastTrack = track;

            if (++chunkIndex >= tracks.Length)
                chunkIndex = 0;
        }
    }

    public void DestroyChunk(TrackMovement thisTrack)
    {
        //This method reuses the tracks when they are "destroyed"
        Vector3 newPos = lastTrack.transform.position;

        newPos.x += trackSize;

        SetTrackNumber(thisTrack);
        thisTrack.gameObject.GetComponent<ObstacleSpawner>().Spawn();
        lastTrack = thisTrack.gameObject;
        lastTrack.transform.position = newPos;
    }

    void SetTrackNumber(TrackMovement track)
    {
        //Sets the track number
        trackCount++;
        track.TrackNumber = trackCount;
    }
}
