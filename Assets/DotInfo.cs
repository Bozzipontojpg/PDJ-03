using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotInfo : MonoBehaviour
{
    private Dot dot;
    
    private int dotValue;

    public void SetDot(Dot d, int v)
    {
        dot = d;
        dotValue = v;
        
        if(dotValue < 0)
            StartCoroutine(DestroyDot());
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        
        dot.InteractDot(dotValue);
        Destroy(gameObject);
    }
    
    private IEnumerator DestroyDot()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
