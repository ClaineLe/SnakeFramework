#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class GuildCreateSubCtrlWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GuildCreateSubCtrl);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 5, 5);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "btnCreate", _g_get_btnCreate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ipGuildName", _g_get_ipGuildName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ipGuildDesc", _g_get_ipGuildDesc);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dpGuildNeed", _g_get_dpGuildNeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "btnClose", _g_get_btnClose);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "btnCreate", _s_set_btnCreate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ipGuildName", _s_set_ipGuildName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ipGuildDesc", _s_set_ipGuildDesc);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dpGuildNeed", _s_set_dpGuildNeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "btnClose", _s_set_btnClose);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GuildCreateSubCtrl gen_ret = new GuildCreateSubCtrl();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GuildCreateSubCtrl constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_btnCreate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.btnCreate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ipGuildName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ipGuildName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ipGuildDesc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ipGuildDesc);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dpGuildNeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dpGuildNeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_btnClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.btnClose);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_btnCreate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.btnCreate = (UnityEngine.UI.Button)translator.GetObject(L, 2, typeof(UnityEngine.UI.Button));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ipGuildName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ipGuildName = (UnityEngine.UI.InputField)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ipGuildDesc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ipGuildDesc = (UnityEngine.UI.InputField)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dpGuildNeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dpGuildNeed = (UnityEngine.UI.Dropdown)translator.GetObject(L, 2, typeof(UnityEngine.UI.Dropdown));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_btnClose(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                GuildCreateSubCtrl gen_to_be_invoked = (GuildCreateSubCtrl)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.btnClose = (UnityEngine.UI.Button)translator.GetObject(L, 2, typeof(UnityEngine.UI.Button));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
