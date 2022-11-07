using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public BoxData data;
    
    void Start()
    {
        transform.localScale = new Vector3(data.size, data.size, data.size);

        GetComponent<Renderer>().material = data.mat;

        GetComponent<Rigidbody>().mass = data.mass;
       
    }
}
