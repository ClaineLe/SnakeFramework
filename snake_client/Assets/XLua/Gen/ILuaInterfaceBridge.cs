﻿#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System;


namespace XLua.CSObjectWrap
{
    public class ILuaInterfaceBridge : LuaBase, ILuaInterface
    {
	    public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
		    return new ILuaInterfaceBridge(reference, luaenv);
		}
		
		public ILuaInterfaceBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
        {
        }
		
        

        
        
        
		
		
	}
}
