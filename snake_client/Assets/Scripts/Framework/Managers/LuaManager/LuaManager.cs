using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaManager : BaseManager<LuaManager>
{
    private LuaEnv _luaEnv;
    private ILuaFrameworkInterface _iLuaFramework;
    public override void Init()
    {
        base.Init();
        this._luaEnv = CreateLuaEnv();
    }
    private XLua.LuaEnv CreateLuaEnv()
    {
        XLua.LuaEnv luaEnv = new XLua.LuaEnv();
        /*
        luaEnv.AddBuildin("rapidjson", XLua.LuaDLL.Lua.LoadRapidJson);
        luaEnv.AddBuildin("lpeg", XLua.LuaDLL.Lua.LoadLpeg);
        luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadLuaProfobuf);
        luaEnv.AddBuildin("ffi", XLua.LuaDLL.Lua.LoadFFI);
         */
        luaEnv.AddLoader(this.LoadLuaScript);
        return luaEnv;
    }
    public byte[] LoadLuaScript(ref string filepath)
    {
        return Singleton<SourceManager>.GetInstance().LoadCustomData(filepath, ".lua");
    }

    public void StartUp()
    {
        this._luaEnv.Global.Get<XLua.LuaFunction>("require").Call("StartUp");
        this._iLuaFramework = this.GetLuaInterface<ILuaFrameworkInterface>();
        this._iLuaFramework.Launch();
    }

    public T GetLuaInterface<T>() where T : ILuaInterface
    {
        return this._luaEnv.Global.Get<T>(typeof(T).Name);
    }
}
