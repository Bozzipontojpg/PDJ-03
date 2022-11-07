using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    private List<CanvasGroup> windows = new List<CanvasGroup>();

    [SerializeField] 
    private int index;
    
    public void OpenWindow(int index)
    {
        this.index = index;
        for (int i = 0; i < windows.Count; i++)
        {
            SetWindow(i, i == index);
        }
    }
    
    private void SetWindow(int i, bool state)
    {
        windows[i].alpha = state ? 1 : 0;
        windows[i].interactable = state;
        windows[i].blocksRaycasts = state;
    }

    private void OnValidate()
    {
        OpenWindow(index);
    }
}
