using UnityEngine;
using System.Collections;

[XLua.CSharpCallLua]
public interface ILuaPanelInterface : ILuaInterface
{
    void LoadSuccess(GameObject screenRoot, string luaPath);

    void Release();
}
