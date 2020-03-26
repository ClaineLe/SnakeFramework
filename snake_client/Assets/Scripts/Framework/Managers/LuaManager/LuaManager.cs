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

    public LuaTable NewTable() {
        return this._luaEnv.NewTable();
    }

    public object[] DoString(byte[] chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return this._luaEnv.DoString(chunk, chunkName, env);
    }

    public void StartUp(GameFacade gameFacade)
    {
        this._luaEnv.Global.Get<XLua.LuaFunction>("require").Call("StartUp");
        this._iLuaFramework = this.GetLuaInterface<ILuaFrameworkInterface>();
        this._iLuaFramework.Launch(gameFacade);
    }

    public T GetLuaInterface<T>(LuaTable luaTable = null, string tableName = null) where T : ILuaInterface
    {
        if (luaTable == null)
            luaTable = this._luaEnv.Global;
        if (string.IsNullOrEmpty(tableName))
            tableName = typeof(T).Name;
        return luaTable.Get<T>(tableName);
    }
}
