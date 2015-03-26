using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using LitJson;

public class RtmpS2C : MonoBehaviour
{

    public LuaManager_new luaManager;

    public MsgStore msgStore;

    //public GameManager gameManager;

    // Use this for initialization
    void Start()
    {

        //DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnClick_Test()
    {
        //print("OnClick_Test .....");
        //string str_OnConnect = @"OnConnect[]";
        //string str_onbegingame = @"onBeginGame[{""data"":{""Lines"": [],""Cards"":""5-2-10,6-9-3,13-3-2,3-6-13,1-2-7""}}]";

        string str_donothing = @"donothing[]";
        OnServerMSG(str_donothing);
        //StartCoroutine(ReadTestJson("http://192.168.152.205:80/testjson/onBeginGame.json.txt"));
    }
    public void OnClick_TestJson()
    {
        //string str_onbegingame = @"onBeginGame[{""data"":{""Lines"": [],""Cards"":""5-2-10,6-9-3,13-3-2,3-6-13,1-2-7""}}]";
        //OnServerMSG(str_onbegingame);
        //StartCoroutine(ReadTestJson("http://192.168.152.205:80/testjson/onBeginGame.json.txt"));
        StartCoroutine(ReadTestJson("http://192.168.152.205:80/testjson/onBeginGame_3.json.txt"));
        //StartCoroutine(ReadTestJson("http://192.168.152.205:80/testjson/updateJP.json.txt"));
    }

    IEnumerator ReadTestJson(string url)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            if (www.error != null)
                Debug.LogError("www.error : " + www.error);
            else
            {

                print(www.text);
                OnServerMSG(www.text);

            }
        }

    }
    
    // ios 收到資料後會呼叫這個方法
    public void OnServerMSG(string _result)
    {
        
        if(!(_result.Contains("updateJP") || _result.Contains("updateJPList")))
        {

            Debug.Log("Unity OnServerMSG " + _result);
            msgStore.Store(_result);
        }
        
        //GameManager.GetDisWindow().AddString("OnServerMSG " + _result);

        //luaManager.CallLuaFuction("OnServerMSG", _result);
        //float t = Time.realtimeSinceStartup;
        luaManager.CallLuaFuction("OnServerMSG", _result);
        //print("lua cost time: " + (Time.realtimeSinceStartup - t));
    }

}
