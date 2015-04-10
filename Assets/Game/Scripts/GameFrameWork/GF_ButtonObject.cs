using UnityEngine;


public class GF_ButtonObject : MonoBehaviour
{

    private LuaManager_new luamanager;
    public UIButton uibutton;

    // 要呼叫Lua方法的名稱
    public string Name_CallLuaFunction;

    public string Name_LongPressCallLua;

    // 參數
    public string str_parms;

    public bool bClickDisable;

    // 傳送參數呼叫
    public bool bUseParam;

    // OnPress
    private bool haveDone;
    private bool bpressing;
    private float fpresstime_first;


    void Awake()
    {

        luamanager = GameObject.Find("LuaManager").GetComponent<LuaManager_new>();
        if (luamanager == null)
            Debug.LogError("can't found luamanager !");
    }

    void Update()
    {
        if(bpressing && !haveDone)
        {
            if(Time.time - fpresstime_first > 1.0f)
            {
                if (!string.IsNullOrEmpty(Name_LongPressCallLua))
                {
                    luamanager.CallLuaFuction(Name_LongPressCallLua);
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
            haveDone = true;

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

    public void OnPress()
    {
        if (haveDone)
        {
        }
        else
        {
            if (bpressing)
            {
                //print("close");
                //bpressing = false;
            }
            else
            {
                //print("open");
                bpressing = true;

                fpresstime_first = Time.time;
            }
        }
    }       

}