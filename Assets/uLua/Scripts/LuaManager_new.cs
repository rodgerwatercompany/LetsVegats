﻿using System;
using UnityEngine;

public class LuaManager_new : MonoBehaviour
{

    public TextAsset[] requireFiles;
    public TextAsset[] scriptFiles;

    private LuaScriptMgr luaMgr = null;
    public Timer timer = null;
    
    static LuaManager_new _instance;

    static public LuaManager_new Instance()
    {

        if (_instance == null)
        {
            _instance = GameObject.Find("LuaManager").GetComponent<LuaManager_new>();
            return _instance;
        }
        else
            return _instance;

    }

    void Awake()
    {

        luaMgr = new LuaScriptMgr();

        foreach (TextAsset ta in scriptFiles)
            luaMgr.DoString(ta.text);


        luaMgr.CallLuaFunction("Awake");
    }

    // Use this for initialization
    void Start()
    {
        luaMgr.CallLuaFunction("Start");
    }

    // Update is called once per frame
    void Update()
    {

        if (timer != null)
        {
            timer.OnUpdate(Time.deltaTime);
        }

        if (luaMgr != null)
        {
            luaMgr.Update();
        }
    }

    public TextAsset GetRequireTextAsset(string filename)
    {

        //Debug.Log("filename is " + filename);
        //Point first = Array.Find(points, p => p.X * p.Y > 100000);
        TextAsset find = Array.Find(requireFiles, p => p.name == filename);

        return find;
    }
    

    public void CallLuaGameObject(string name_gameobject, string name_luafunc, string str_paras)
    {
        luaMgr.CallLuaFunction("Call", name_gameobject, name_luafunc, str_paras);

    }

    public void CallLuaFuction(string name_luafunc, params object[] paras)
    {
        luaMgr.CallLuaFunction(name_luafunc, paras);
    }
}