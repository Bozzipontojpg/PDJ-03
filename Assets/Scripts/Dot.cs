using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public DotData data;
    
    void Start()
    {
        transform.localScale = new Vector3(data.size, data.size, data.size);

        GetComponent<Renderer>().material = data.mat;       
    }
}
