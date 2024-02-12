using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //This is used to procedurally generate a level
    [SerializeField] GameObject obstacleHolder;
    [SerializeField] GameObject featherHolder;
    [SerializeField] Transform[] spawnLocations;

    public void Spawn()
    {
        // This is run is time the track is "destroyed" (reused)
        // Selects a number between 1 or 2
        int obstacleType = Random.Range(1, 3);

        switch (obstacleType)
        {
            //if 1
            case 1:
                SpawnObstacles();
                break;
            //if 2
            case 2:
                SpawnFeathers();
                break;
        }
    }

    void SpawnFeathers()
    {
        ActivateRandomChild(featherHolder.transform, spawnLocations[0]);
    }

    void SpawnObstacles()
    {   //I have predifened locations in heirarchy named 1,2,3 and 4
        //I use these to set the location of spawned obstacles
        foreach (var item in spawnLocations)
        {
            ActivateRandomChild(obstacleHolder.transform, item);
        }
    }

    void ActivateRandomChild(Transform parentObject, Transform referenceObject)
    {
        // Deactivate all children first
        foreach (Transform child in parentObject)
        {
            child.gameObject.SetActive(false);
        }

        // Randomly select one child
        int index = Random.Range(0, parentObject.childCount);
        Transform selectedChild = parentObject.GetChild(index);

        // Activate the selected child
        selectedChild.gameObject.SetActive(true);

        // Set the selected child's Z position to match the reference object's Z position
        Vector3 newPosition = selectedChild.localPosition;
        newPosition.x = referenceObject.localPosition.x;
        selectedChild.localPosition = newPosition;
    }
}
