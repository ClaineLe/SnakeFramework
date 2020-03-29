using UnityEngine;
using System.Collections;

[XLua.CSharpCallLua]
public interface ILuaPanelInterface : ILuaInterface
{
    void LoadSuccess(UIPanel uiPanel, string luaPath);

    void Release();

    int GetPriority();
    
    bool GetUseMask();
    
    bool GetAlwaysShow();
    
    bool GetHideOtherScreenWhenThisOnTop();

}
