using UnityEngine;
using System.Collections;

[XLua.CSharpCallLua]
public interface ILuaPanelInterface : ILuaInterface
{
    void CreatePanel();
    void OnLoadSuccess(UIPanel panel);
    void ReleasePanel();

    int mPriority { get; }
    bool mUseMask { get; }
    bool mAlwaysShow { get; }
    bool mHideOtherScreenWhenThisOnTop { get; }
    
}
