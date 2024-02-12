using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IntroManager : MonoBehaviour
{
    //Handles the intro animation


    [Inject]
    public GameManager gameManager { get; set; }
    public UIAnimationHandler uIAnimationHandler;
    public float fadeInDuration = 2f; // Duration of the fade-in effect


    //Fade out
    public void StartIntro()
    {
       uIAnimationHandler.blackFadeGroup.FadeOut(fadeInDuration);
    }

    public void EndIntro()
    {
        RemoveLookAtTarget();
    }

    //Removes look at, because the actual gameplay does not require a look at target
    void RemoveLookAtTarget()
    {
        gameManager.gameCamera.LookAt = null;
        gameManager.transitionCamera.SetActive(false);
        gameManager.GameStarted = true;
    }
}
