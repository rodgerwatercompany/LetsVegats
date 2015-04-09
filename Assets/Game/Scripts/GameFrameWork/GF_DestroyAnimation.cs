using UnityEngine;
using System.Collections;

public class GF_DestroyAnimation : MonoBehaviour {

    public Animator animator;
    public  LuaManager_new luamanager;
    public string Name_CallLuaFunciton;

    // 參數
    public string str_parms;
    // 傳送參數呼叫
    public bool bUseParam;


    public void CloseAnimation()
    {

        gameObject.SetActive(false);

        if (!bUseParam)
        {

            luamanager.CallLuaFuction(Name_CallLuaFunciton);
        }
        else
        {

            luamanager.CallLuaFuction(Name_CallLuaFunciton, str_parms);
        }
    }
}
