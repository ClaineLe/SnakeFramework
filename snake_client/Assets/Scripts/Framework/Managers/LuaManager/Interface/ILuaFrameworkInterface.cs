using UnityEngine;
using System.Collections;

[XLua.CSharpCallLua]
public interface ILuaFrameworkInterface : ILuaInterface
{
    void Launch(GameFacade gameFacade);
}
