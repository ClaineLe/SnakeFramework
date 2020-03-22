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
    
    public class TutorialTestEnumWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Tutorial.TestEnum), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Tutorial.TestEnum), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Tutorial.TestEnum), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E1", Tutorial.TestEnum.E1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E2", Tutorial.TestEnum.E2);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Tutorial.TestEnum), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushTutorialTestEnum(L, (Tutorial.TestEnum)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E1"))
                {
                    translator.PushTutorialTestEnum(L, Tutorial.TestEnum.E1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E2"))
                {
                    translator.PushTutorialTestEnum(L, Tutorial.TestEnum.E2);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Tutorial.TestEnum!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Tutorial.TestEnum! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class XLuaTestMyEnumWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(XLuaTest.MyEnum), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(XLuaTest.MyEnum), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(XLuaTest.MyEnum), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E1", XLuaTest.MyEnum.E1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E2", XLuaTest.MyEnum.E2);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(XLuaTest.MyEnum), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushXLuaTestMyEnum(L, (XLuaTest.MyEnum)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E1"))
                {
                    translator.PushXLuaTestMyEnum(L, XLuaTest.MyEnum.E1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E2"))
                {
                    translator.PushXLuaTestMyEnum(L, XLuaTest.MyEnum.E2);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for XLuaTest.MyEnum!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for XLuaTest.MyEnum! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class TutorialDerivedClassTestEnumInnerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E3", Tutorial.DerivedClass.TestEnumInner.E3);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E4", Tutorial.DerivedClass.TestEnumInner.E4);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushTutorialDerivedClassTestEnumInner(L, (Tutorial.DerivedClass.TestEnumInner)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E3"))
                {
                    translator.PushTutorialDerivedClassTestEnumInner(L, Tutorial.DerivedClass.TestEnumInner.E3);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E4"))
                {
                    translator.PushTutorialDerivedClassTestEnumInner(L, Tutorial.DerivedClass.TestEnumInner.E4);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Tutorial.DerivedClass.TestEnumInner!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Tutorial.DerivedClass.TestEnumInner! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class EScreenPriorityWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(EScreenPriority), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(EScreenPriority), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(EScreenPriority), L, null, 10, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Default", EScreenPriority.Default);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobby", EScreenPriority.PriorityLobby);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobbyFace", EScreenPriority.PriorityLobbyFace);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobbyForSystem", EScreenPriority.PriorityLobbyForSystem);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobbyForMatchingSystem0", EScreenPriority.PriorityLobbyForMatchingSystem0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLowLoadingCommonMessageBoxTips", EScreenPriority.PriorityLowLoadingCommonMessageBoxTips);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobbyForLoading", EScreenPriority.PriorityLobbyForLoading);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityUpLoadingCommonMessageBoxTips", EScreenPriority.PriorityUpLoadingCommonMessageBoxTips);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PriorityLobbyForNewPlayerGuide", EScreenPriority.PriorityLobbyForNewPlayerGuide);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(EScreenPriority), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushEScreenPriority(L, (EScreenPriority)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Default"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.Default);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobby"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobby);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobbyFace"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobbyFace);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobbyForSystem"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobbyForSystem);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobbyForMatchingSystem0"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobbyForMatchingSystem0);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLowLoadingCommonMessageBoxTips"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLowLoadingCommonMessageBoxTips);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobbyForLoading"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobbyForLoading);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityUpLoadingCommonMessageBoxTips"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityUpLoadingCommonMessageBoxTips);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PriorityLobbyForNewPlayerGuide"))
                {
                    translator.PushEScreenPriority(L, EScreenPriority.PriorityLobbyForNewPlayerGuide);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for EScreenPriority!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for EScreenPriority! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}