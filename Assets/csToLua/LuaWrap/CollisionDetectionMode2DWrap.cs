﻿using UnityEngine;
using System;
using LuaInterface;

public class CollisionDetectionMode2DWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", CollisionDetectionMode2D.None),
		new LuaEnum("Continuous", CollisionDetectionMode2D.Continuous),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CollisionDetectionMode2D", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.CollisionDetectionMode2D", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CollisionDetectionMode2D o = (CollisionDetectionMode2D)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

