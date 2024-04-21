using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdColor : MonoBehaviour
{
    #region Fields
    [SerializeField] BirdSettings _userSettings;
    [SerializeField] BirdSettings _defaultSettings;
    [SerializeField] Color[] _randomColors;

    #endregion

    void Start()
    {
        SetDefaultColor();
    }

    // Picks a random color for the bird
    public void RandomizeBird()
    {
        _userSettings.BodyColor = GetRandomColor();
        _userSettings.TailColor = GetRandomColor();

        SetBirdColor(_userSettings);
    }

    // Gets a random color from the defined list
    public Color GetRandomColor()
    {
        return _randomColors[UnityEngine.Random.Range(0, _randomColors.Length)];
    }

    // Sets the material colors
    public void SetBirdColor(BirdSettings settings)
    {
        foreach (var setting in settings.ColorSettings)
        {
            if (setting.Name == "Tail")
                setting.Material.SetColor("_BaseColor", settings.TailColor);
            else
                setting.Material.SetColor("_BaseColor", settings.BodyColor);
        }
    }

    public void SetDefaultColor()
    {
        SetBirdColor(_defaultSettings);
    }
}

[Serializable]
public class ColorSettings
{
    public string Name;
    public Material Material;
}

