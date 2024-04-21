using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skyward/Bird Settings", order = 1)]
public class BirdSettings : ScriptableObject
{
    public Color BodyColor;
    public Color TailColor;
    public ColorSettings[] ColorSettings;
}