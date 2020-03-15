using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrlBase : UIEventAutoRelease
{
    [HideInInspector]
    public Canvas ctrlCanvas;

    private void Awake()
    {
        this.ctrlCanvas = GetComponent<Canvas>();
        BindControls();
    }

    public virtual void BindControls() 
    {

    }
}