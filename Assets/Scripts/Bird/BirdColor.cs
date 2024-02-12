using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdColor : MonoBehaviour
{
    [SerializeField] BirdSettings userSettings;
    [SerializeField] BirdSettings defaultSettings;
    [SerializeField] Color[] randomColors;

    void Start()
    {
        SetDefaultColor();
    }

    // Picks a random color for the bird
    public void RandomizeBird()
    {
        userSettings.bodyColor = GetRandomColor();
        userSettings.tailColor = GetRandomColor();

        SetBirdColor(userSettings);
    }

    // Gets a random color from the defined list
    public Color GetRandomColor()
    {
        return randomColors[UnityEngine.Random.Range(0, randomColors.Length)];
    }

    // Sets the material colors
    public void SetBirdColor(BirdSettings settings)
    {
        foreach (var setting in settings.colorSettings)
        {
            if (setting.name == "Tail")
                setting.material.SetColor("_BaseColor", settings.tailColor);
            else
                setting.material.SetColor("_BaseColor", settings.bodyColor);
        }
    }

    public void SetDefaultColor()
    {
        SetBirdColor(defaultSettings);
    }
}

[Serializable]
public class ColorSettings
{
    public string name;
    public Material material;
}

