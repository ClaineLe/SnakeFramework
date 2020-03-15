using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrlBase : UIEventAutoRelease
{
    [HideInInspector]
    public Canvas ctrlCanvas;

    [Tooltip("ScreenBase 层级")]
    public EScreenPriority screenPriority = EScreenPriority.PriorityLobbyForSystem;

    private void Awake()
    {
        this.ctrlCanvas = GetComponent<Canvas>();
        BindControls();
    }

    public virtual void BindControls() 
    {

    }
}