using UnityEngine;
using System.Collections;

[XLua.CSharpCallLua]
public interface ILuaScreenInterface : ILuaInterface
{
    void LoadSuccess(GameObject screenRoot, string luaPath);

    void Release();
}
