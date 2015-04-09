using System;
using LuaInterface;

public class wheelWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnClick_Start", OnClick_Start),
		new LuaMethod("OnClick_Stop", OnClick_Stop),
		new LuaMethod("SetSpeed", SetSpeed),
		new LuaMethod("SetSpecifyNum", SetSpecifyNum),
		new LuaMethod("New", _Createwheel),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("bCan_Start", get_bCan_Start, set_bCan_Start),
		new LuaField("fspeed", get_fspeed, set_fspeed),
		new LuaField("waittime", get_waittime, set_waittime),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _Createwheel(IntPtr L)
	{
		LuaDLL.luaL_error(L, "wheel class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(wheel));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "wheel", typeof(wheel), regs, fields, "UnityEngine.MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bCan_Start(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bCan_Start");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bCan_Start on a nil value");
			}
		}

		wheel obj = (wheel)o;
		LuaScriptMgr.Push(L, obj.bCan_Start);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fspeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fspeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fspeed on a nil value");
			}
		}

		wheel obj = (wheel)o;
		LuaScriptMgr.Push(L, obj.fspeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_waittime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name waittime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index waittime on a nil value");
			}
		}

		wheel obj = (wheel)o;
		LuaScriptMgr.Push(L, obj.waittime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bCan_Start(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bCan_Start");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bCan_Start on a nil value");
			}
		}

		wheel obj = (wheel)o;
		obj.bCan_Start = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fspeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fspeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fspeed on a nil value");
			}
		}

		wheel obj = (wheel)o;
		obj.fspeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_waittime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name waittime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index waittime on a nil value");
			}
		}

		wheel obj = (wheel)o;
		obj.waittime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick_Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		wheel obj = LuaScriptMgr.GetNetObject<wheel>(L, 1);
		obj.OnClick_Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick_Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		wheel obj = LuaScriptMgr.GetNetObject<wheel>(L, 1);
		obj.OnClick_Stop();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSpeed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		wheel obj = LuaScriptMgr.GetNetObject<wheel>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.SetSpeed(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSpecifyNum(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		wheel obj = LuaScriptMgr.GetNetObject<wheel>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SetSpecifyNum(arg0);
		return 0;
	}
}

