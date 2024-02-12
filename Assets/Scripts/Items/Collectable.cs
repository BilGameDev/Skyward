using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //Triggers when it comes into contact with the bird
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BirdCollector>().OnCollect();
            gameObject.SetActive(false);
        }
    }
}
