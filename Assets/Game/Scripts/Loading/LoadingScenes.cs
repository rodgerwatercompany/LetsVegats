using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using LitJson;

public class LoadingScenes : MonoBehaviour
{

#if UNITY_IPHONE
    const string NAME_platform = "IOS";
#elif UNITY_ANDROID
    const string NAME_platform = "Android";
#endif

    public UIProgressBar uiprogressbar;
    private WWW www_getGameListInfo;
    private WWW www_getUserInfo;
    private WWW www_getLobbyInfo;

    private WWW www_getlobbyAB;
    
    string url_gamelistinfo = "http://192.168.152.205/LetsVegs/Loading/GameListInfo.json.txt";
    string url_userinfo = "http://192.168.152.205/LetsVegs/Loading/UserInfo.json.txt";
    string url_lobbyinfo = "http://192.168.152.205/LetsVegs/Loading/LobbyInfo.json.txt";
    //string url_lobbyAB = "http://192.168.152.205/LetsVegs/" + NAME_platform + "/GameLobby_v5_4.unity3d";
    string url_lobbyAB = "http://192.168.152.205/LetsVegs/" + NAME_platform + "/GameLobby_v11_3.unity3d";

    private float progress_now;

    private List<WWW> list_wwwload;

    private bool SW_Loading;
    private bool SW_LoadLevel;
    private int num_lobbyversion;
    void Start()
    {

        SW_Loading = false;
        SW_LoadLevel = false;

        progress_now = 0.0f;
        
        //this.OnClick_StartLoading();
    }

    // Update is called once per frame
    void Update()
    {

        // 如果開始下載
        if(SW_Loading)
        {
            // 計算實際 progress
            int cnt_done = 0;
            float progress_real = 0.0f;
            int len = list_wwwload.Count;
            
            for(int i = 0; i < len ; i++)
            {
                if (list_wwwload[i] == null)
                {
                    cnt_done++; progress_real += 1.0f / len;
                }
                else
                {
                    progress_real += list_wwwload[i].progress;
                }
            }

            if (progress_now < progress_real)
            {
                progress_now += 0.1f * 5.0f * Time.deltaTime ;
            }

            if (progress_now >= 0.99f)
            {
                progress_now = 1.0f;

                SW_Loading = false;

                // 開始載入大廳
                SW_LoadLevel = true;
            }

            uiprogressbar.value = progress_now;
        }
        else if(SW_LoadLevel)
        {

            SW_LoadLevel = false;

            JsonData jd_version = JsonManager.GetJD("LobbyInfo", new string[] { "Lobby", "Version" });

            if (jd_version != null)
                StartCoroutine(GetLobbyAB(url_lobbyAB, (int)jd_version));
            else
                Debug.Log("Can't found Lobby version");
        }

    }

    void OnGUI()
    {
        //GUILayout.Label("Have Lobby AB : " + Caching.IsVersionCached(url_lobbyAB, 1).ToString());
        GUILayout.Label("Have Lobby AB : " + ABCaching.IsVersionCached(url_lobbyAB, 1).ToString());
        GUILayout.Label("Now Lobby Latest Version is " + num_lobbyversion);
    }

    public void OnClick_StartLoading()
    {

        string str_getparams = "?p=";
        str_getparams += DateTime.Now.ToString("yyyyMMddHHmmsstt");

        list_wwwload = new List<WWW>();
        www_getGameListInfo = null;
        www_getUserInfo = null;
        www_getLobbyInfo = null;

        StartCoroutine(GetInfo(url_gamelistinfo + str_getparams, www_getGameListInfo, "GameListInfo"));
        StartCoroutine(GetInfo(url_userinfo + str_getparams, www_getUserInfo, "UserInfo"));
        StartCoroutine(GetInfo(url_lobbyinfo + str_getparams, www_getLobbyInfo, "LobbyInfo"));
        
        // 開始顯示"進度條"
        SW_Loading = true;
    }

    public void OnClick_CleanCache()
    {

        //Caching.CleanCache();
        ABCaching.DeleteALL();
    }

    IEnumerator GetInfo(string url,WWW www_getinfo, string name_jsonkey)
    {

        using (www_getinfo = new WWW(url))
        {
            list_wwwload.Add(www_getinfo);
            yield return www_getinfo;

            if (www_getinfo.error != null)
                Debug.Log("WWW url : " + url + " , download had an error:" + www_getinfo.error);
            else
            {
                print(www_getinfo.text);
                JsonManager.Init(name_jsonkey, www_getinfo.text);
            }
            int idx = list_wwwload.FindIndex(x => x == www_getinfo);

            //www_getGameListInfo = null;
            list_wwwload[idx] = null;
        }
    }


    IEnumerator GetLobbyAB(string url,int version)
    {
        if (ABCaching.IsVersionCached(url, version))
        {

            string path = ABCaching.getPath(url, version);
            using (www_getlobbyAB = new WWW(path))
            {

                yield return www_getlobbyAB;

                if (www_getlobbyAB.error != null)
                    Debug.LogError("WWW load cache had an error:" + www_getlobbyAB.error);
                else
                {

                    ABManager.assetbundle_Lobby = www_getlobbyAB.assetBundle;
                    Application.LoadLevel("Lobby");
                    
                }
            }
        }
        else
        {

            //using (www_getlobbyAB = WWW.LoadFromCacheOrDownload(url, version))
            using (www_getlobbyAB = new WWW(url))
            {

                yield return www_getlobbyAB;

                if (www_getlobbyAB.error != null)
                    Debug.LogError("WWW download had an error:" + www_getlobbyAB.error);
                else
                {

                    if (ABManager.assetbundle_Lobby != null)
                        ABManager.assetbundle_Lobby.Unload(true);

                    ABCaching.Save(www_getlobbyAB.bytes, url, version);

                    ABManager.assetbundle_Lobby = www_getlobbyAB.assetBundle;
                    Application.LoadLevel("Lobby");
                }
            }

        }
        this.num_lobbyversion = version;
        Debug.Log("載完LobbyAB !");

    }

}
