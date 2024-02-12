using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] ParticleSystem acquiredEffect;
    [SerializeField] GameObject easterEggObject;
    public void Acquire()
    {
        acquiredEffect.Play();
        easterEggObject.SetActive(false);
    }
}
