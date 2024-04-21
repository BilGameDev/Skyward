using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    #region Fields
    [SerializeField] CanvasGroup _mainMenuGroup;
    [SerializeField] RectTransform _mainMenuPanel;
    [SerializeField] RectTransform _mainCanvas;
    [SerializeField] CanvasGroup _fadeGroup;

    #endregion

    void Start()
    {
        _fadeGroup.FadeOut(1);
    }

    //Tweens the mai menu panels in
    public void OpenMenu()
    {
        _mainMenuGroup.FadeIn(.3f);
        _mainMenuPanel.MoveUI(new Vector2(.5f, .3f), _mainCanvas, 1f, Platinio.UI.PivotPreset.LowerCenter).SetEase(Ease.EaseOutElastic);
    }

    public void CloseMenu()
    {
        _mainMenuPanel.MoveUI(new Vector2(.5f, -1f), _mainCanvas, 1f, Platinio.UI.PivotPreset.LowerCenter);
        _mainMenuGroup.FadeOut(.3f);
    }
}
