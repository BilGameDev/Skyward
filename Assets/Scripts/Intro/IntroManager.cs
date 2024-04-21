using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IntroManager : MonoBehaviour
{
    //Handles the intro animation

    #region Fields

    [Inject]
    public GameManager gameManager { get; set; }
    public UIAnimationHandler UIAnimationHandler;
    public float FadeInDuration = 2f; // Duration of the fade-in effect

    #endregion


    //Fade out
    public void StartIntro()
    {
       UIAnimationHandler.BlackFadeGroup.FadeOut(FadeInDuration);
    }

    public void EndIntro()
    {
        RemoveLookAtTarget();
    }

    //Removes look at, because the actual gameplay does not require a look at target
    void RemoveLookAtTarget()
    {
        gameManager.GameCamera.LookAt = null;
        gameManager.TransitionCamera.SetActive(false);
        gameManager.GameStarted = true;
    }
}
