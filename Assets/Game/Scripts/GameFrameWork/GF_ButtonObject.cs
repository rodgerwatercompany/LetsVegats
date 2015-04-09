using UnityEngine;
using System.Collections;


public class GF_ButtonObject : MonoBehaviour
{

    private LuaManager_new luamanager;
    public UIButton uibutton;

    // 要呼叫Lua方法的名稱
    public string Name_CallLuaFunction;

    // 參數
    public string str_parms;

    public bool bClickDisable;

    // 傳送參數呼叫
    public bool bUseParam;

    
    void Awake()
    {

        luamanager = GameObject.Find("LuaManager").GetComponent<LuaManager_new>();
        if (luamanager == null)
            Debug.LogError("can't found luamanager !");
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

        if (uibutton.state != UIButtonColor.State.Disabled && uibutton.enabled)
        {

            if (bClickDisable)
                SetState("Disabled");

            if (!bUseParam)
            {

                luamanager.CallLuaFuction(Name_CallLuaFunction);
            }
            else
            {
                luamanager.CallLuaFuction(Name_CallLuaFunction, str_parms);
            }

        }
    }
}