using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrlBase : UIController
{
    [HideInInspector]
    public Canvas ctrlCanvas;

    [Tooltip("ScreenBase 层级")]
    public EScreenPriority screenPriority = EScreenPriority.PriorityLobbyForSystem;
   
    // 是否使用遮罩功能(点击遮罩关闭当前页面)
    [Tooltip("勾选此选项后,打开本界面时会自动激活并更新遮罩面板,\n用户点击到遮罩面板会自动关闭此页面")]
    public bool m_UseMask = false;

    [Tooltip("勾选此选项后,不会被 mHideOtherScreenWhenThisOnTop 控制")]
    public bool mAlwaysShow = false;
    [Tooltip("勾选此选项后,当该界面打开，会隐藏他下面的其他非AlwaysShow界面")]
    public bool mHideOtherScreenWhenThisOnTop = false;

    private void Awake()
    {
        this.ctrlCanvas = GetComponent<Canvas>();
        BindControls();
    }

    protected virtual void BindControls() 
    {

    }
}