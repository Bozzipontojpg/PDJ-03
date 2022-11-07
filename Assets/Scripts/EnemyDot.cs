using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDot : Dot
{
    public GameObject dot;
    public DotData data;
    
    public EnemyDot(GameObject dot, DotData data)
    {
        this.dot = dot;
        this.data = data;
    }
    public void CreateDot()
    {
        dot.transform.localScale = new Vector3(data.size, data.size, data.size);
        
        dot.GetComponent<Renderer>().material = data.mat;
        dot.GetComponent<DotInfo>().SetDot(this, data.value);
    }

    public void InteractDot(int v)
    {
        GameManager.instance.GameOver();
    }
}
