using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] CanvasGroup mainMenuGroup;
    [SerializeField] RectTransform mainMenuPanel;
    [SerializeField] RectTransform mainCanvas;
    [SerializeField] CanvasGroup fadeGroup;

    void Start()
    {
        fadeGroup.FadeOut(1);
    }

    //Tweens the mai menu panels in
    public void OpenMenu()
    {
        mainMenuGroup.FadeIn(.3f);
        mainMenuPanel.MoveUI(new Vector2(.5f, .3f), mainCanvas, 1f, Platinio.UI.PivotPreset.LowerCenter).SetEase(Ease.EaseOutElastic);
    }

    public void CloseMenu()
    {
        mainMenuPanel.MoveUI(new Vector2(.5f, -1f), mainCanvas, 1f, Platinio.UI.PivotPreset.LowerCenter);
        mainMenuGroup.FadeOut(.3f);
    }
}
