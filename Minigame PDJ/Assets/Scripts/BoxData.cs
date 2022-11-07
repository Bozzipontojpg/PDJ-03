using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxData", menuName = "BoxData", order = 0)]

public class BoxData : ScriptableObject
{
    public float mass;

    public int size;

    public int value;

    public Material mat;
}
