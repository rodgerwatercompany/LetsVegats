using System;
using LuaInterface;

public class RtmpC2SWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Connect", Connect),
		new LuaMethod("LoginBySid", LoginBySid),
		new LuaMethod("TakeMachine", TakeMachine),
		new LuaMethod("onLoadInfo2", onLoadInfo2),
		new LuaMethod("creditExchange", creditExchange),
		new LuaMethod("BeginGame", BeginGame),
		new LuaMethod("EndGame", EndGame),
		new LuaMethod("HitFree", HitFree),
		new LuaMethod("HitBonus", HitBonus),
		new LuaMethod("EndBonus", EndBonus),
		new LuaMethod("BalanceExchange", BalanceExchange),
		new LuaMethod("MachineLeave", MachineLeave),
		new LuaMethod("Close", Close),
		new LuaMethod("New", _CreateRtmpC2S),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("sid", get_sid, set_sid),
		new LuaField("ip", get_ip, set_ip),
		new LuaField("userid", get_userid, set_userid),
		new LuaField("hallid", get_hallid, set_hallid),
		new LuaField("gamecode", get_gamecode, set_gamecode),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRtmpC2S(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			RtmpC2S obj = new RtmpC2S();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RtmpC2S.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(RtmpC2S));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "RtmpC2S", typeof(RtmpC2S), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sid(IntPtr L)
	{
		LuaScriptMgr.Push(L, RtmpC2S.sid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ip(IntPtr L)
	{
		LuaScriptMgr.Push(L, RtmpC2S.ip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_userid(IntPtr L)
	{
		LuaScriptMgr.Push(L, RtmpC2S.userid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hallid(IntPtr L)
	{
		LuaScriptMgr.Push(L, RtmpC2S.hallid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gamecode(IntPtr L)
	{
		LuaScriptMgr.Push(L, RtmpC2S.gamecode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sid(IntPtr L)
	{
		RtmpC2S.sid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ip(IntPtr L)
	{
		RtmpC2S.ip = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_userid(IntPtr L)
	{
		RtmpC2S.userid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hallid(IntPtr L)
	{
		RtmpC2S.hallid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gamecode(IntPtr L)
	{
		RtmpC2S.gamecode = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Connect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.Connect();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoginBySid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		RtmpC2S.LoginBySid(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TakeMachine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		RtmpC2S.TakeMachine(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onLoadInfo2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.onLoadInfo2();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int creditExchange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		RtmpC2S.creditExchange(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginGame(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		RtmpC2S.BeginGame(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndGame(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		RtmpC2S.EndGame(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HitFree(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		RtmpC2S.HitFree(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HitBonus(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		RtmpC2S.HitBonus(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndBonus(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.EndBonus();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BalanceExchange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.BalanceExchange();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MachineLeave(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.MachineLeave();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Close(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		RtmpC2S.Close();
		return 0;
	}
}

