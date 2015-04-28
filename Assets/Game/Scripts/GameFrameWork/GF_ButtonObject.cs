using UnityEngine;

[System.Serializable]
public struct Func
{
    public string GameObject;
    public string MethodName;
    public string parameter;
}

public class GF_ButtonObject : MonoBehaviour
{
    public UIButton uibutton;

    // 要呼叫Lua的方法
    public Func luaFunc_normal;
    public Func luaFunc_longpress;

    public bool bClickDisable;


    // OnPress
    private bool haveDone;   // 防止長按之後，進行短按。
    private bool bpressing;  // 防止短按之後，進行長按。
    private float fpresstime_first;

    void Update()
    {
        if(bpressing && !haveDone)
        {
            if(Time.time - fpresstime_first > 1.0f)
            {
                if (!string.IsNullOrEmpty(luaFunc_longpress.MethodName))
                {
                    this.CallLua(luaFunc_longpress.GameObject,luaFunc_longpress.MethodName, luaFunc_longpress.parameter);
                    haveDone = true;
                    SetState("Disabled");
                }
            }
        }
    }

    void OnEnable()
    {
        bpressing = false;
        haveDone = false;
    }
    
    public void SetActive(bool sw)
    {

        gameObject.SetActive(sw);

        if (sw)
        {
            SetState("Normal");
        }
    }

    public void SetState(string state)
    {
        switch (state)
        {
            case "Normal":
                uibutton.enabled = true;
                uibutton.SetState(UIButtonColor.State.Normal, false);
                break;
            case "Hover":
                uibutton.SetState(UIButtonColor.State.Hover, false);
                break;
            case "Pressed":
                uibutton.SetState(UIButtonColor.State.Pressed, false);
                break;
            case "Disabled":
                uibutton.enabled = false;
                uibutton.SetState(UIButtonColor.State.Disabled, false);
                break;
        }
    }
    
    public void OnClick()
    {
        if (uibutton.state != UIButtonColor.State.Disabled && uibutton.enabled && !haveDone)
        {
            //haveDone = true;

            if (bClickDisable)
                SetState("Disabled");

            this.CallLua(luaFunc_normal.GameObject, luaFunc_normal.MethodName, luaFunc_normal.parameter);
        }
    }

    public void OnPress()
    {
        if (bpressing)
        {
            //print("close");
            bpressing = false;
        }
        else
        {
            //print("open");
            bpressing = true;

            fpresstime_first = Time.time;
        }
    }       

    private void CallLua(string lua_gameObject,string lua_methodname,string str_parms)
    {
        if(string.IsNullOrEmpty(lua_gameObject))
        {
            if (!string.IsNullOrEmpty(str_parms))
                LuaManager_new.Instance().CallLuaFuction(lua_methodname, str_parms);
            else
                LuaManager_new.Instance().CallLuaFuction(lua_methodname);
        }
        else
        {
            LuaManager_new.Instance().CallLuaGameObject(lua_gameObject, lua_methodname, str_parms);
        }
    }
}