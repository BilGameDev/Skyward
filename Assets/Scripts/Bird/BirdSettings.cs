using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skyward/Bird Settings", order = 1)]
public class BirdSettings : ScriptableObject
{
    public Color bodyColor;
    public Color tailColor;
    public ColorSettings[] colorSettings;
}