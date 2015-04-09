using UnityEngine;
using System.Collections;

public class GF_TimerObject : MonoBehaviour {

    public LuaManager_new luamanager;

    public string Name_CallLuaFunction;

    public float time;

    // 參數
    public string str_parms;
    // 傳送參數呼叫
    public bool bUseParam;

    public bool sw_finishdisable;

    void Start()
    {
        luamanager = GameObject.Find("LuaManager").GetComponent<LuaManager_new>();
    }

    void OnEnable()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {

        yield return new  WaitForSeconds(time);
        
        if (!bUseParam)
        {

            luamanager.CallLuaFuction(Name_CallLuaFunction);
        }
        else
        {

            if(!string.IsNullOrEmpty(Name_CallLuaFunction))
                luamanager.CallLuaFuction(Name_CallLuaFunction, str_parms);
        }

        if (sw_finishdisable)
            Destroy(gameObject);
    }
}
