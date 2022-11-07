using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DotData", menuName = "DotData", order = 0)]

public class DotData : ScriptableObject
{
    public float size;

    public int value;

    public Material mat;
}
