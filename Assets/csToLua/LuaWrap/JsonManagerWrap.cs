using System;
using System.Collections.Generic;
using LuaInterface;

public class JsonManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Init", Init),
		new LuaMethod("Show", Show),
		new LuaMethod("GetJD", GetJD),
		new LuaMethod("New", _CreateJsonManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("dic_jsons", get_dic_jsons, set_dic_jsons),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJsonManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			JsonManager obj = new JsonManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: JsonManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(JsonManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "JsonManager", typeof(JsonManager), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dic_jsons(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, JsonManager.dic_jsons);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dic_jsons(IntPtr L)
	{
		JsonManager.dic_jsons = LuaScriptMgr.GetNetObject<Dictionary<string,LitJson.JsonData>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		JsonManager.Init(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 1);
		JsonManager.Show(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetJD(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LuaTable arg1 = LuaScriptMgr.GetLuaTable(L, 2);
		LitJson.JsonData o = JsonManager.GetJD(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

