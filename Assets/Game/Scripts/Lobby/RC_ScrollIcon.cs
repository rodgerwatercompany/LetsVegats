using UnityEngine;
using System.Collections;

public class RC_ScrollIcon : MonoBehaviour {

#if UNITY_IPHONE
    const string NAME_platform = "IOS";
#elif UNITY_ANDROID
    const string NAME_platform = "Android";
#endif

    public GameObject Ref_progressball;

    public UIButton uibutton_icon;

    public UIButton uibutton_download;

    public UILabel uilabel_levellimit;

    private RC_ProgressBall progressball;
    
    private int icon_gameorder;
    //private string icon_sprintname;    
    //private int icon_state;    // 0:等級太低不能玩; 1:未下載; 2:已下載; 3:Coming soon; 4:下載中
    private int icon_LevelLimit;
    private string icon_ABURL;
    private int icon_ABVersion;
    private string icon_GameSceneName;

    private WWW www_loadAB;
    private bool SW_LoadingAB;

    void Start()
    {
        this.SW_LoadingAB = false;

    }
    void Update()
    {

        // 如果開始下載AB遊戲包
        if(SW_LoadingAB)
        {
            // 如果已經下載完了
            if (www_loadAB == null)
            {
                progressball.value += 0.01f * 10.0f * Time.deltaTime ;
                if(progressball.value >= 1.0f)
                {
                    progressball.value = 1.0f;
                    
                    SW_LoadingAB = false;

                    this.OnFinish_DownLoadAB();

                }
            }
            else
            {
                if(progressball.value < www_loadAB.progress)
                {
                    progressball.value += 0.01f * 10.0f * Time.deltaTime;
                }
            }
        }

    }

    public void Init(   int gameorder,
                        string name_sp,
                        int levellimit,
                        string gamescenename,
                        bool comingsoon,
                        int userlevel,
                        string ABUrl,
                        int ABversion)
    {
        this.icon_gameorder = gameorder;
        this.icon_LevelLimit = levellimit;

        this.icon_GameSceneName = gamescenename;

        this.SetIConSprite(name_sp);


        string url = ABUrl.Replace("PLATFORMNAME", NAME_platform);
        this.icon_ABURL     = url;
        this.icon_ABVersion = ABversion;

        int iconstate = this.GetIconState(comingsoon, userlevel, url, ABversion);
        print("gameOrder is " + icon_gameorder + ", state is " + iconstate);

        this.SetIConButton(iconstate);
        this.SetDownloadSprite(iconstate);
        this.SetLevelLimit(userlevel);
    }


    public void OnClick_DownLoad()
    {
        // disable 下載按鈕
        this.SetDownloadSprite(4); // 下載中

        // 實作下載球
        GameObject gaobj = Instantiate(Ref_progressball,
                                        new Vector3(0.0f, 0.0f, 0.0f),
                                        Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)))
                                        as GameObject;

        gaobj.transform.parent = gameObject.transform;
        gaobj.transform.localPosition = new Vector3(0.0f, -46.27f, 0.0f);
        gaobj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        progressball = gaobj.GetComponent<RC_ProgressBall>();
        progressball.value = 0.0f;


        www_loadAB = null;

        StartCoroutine(DownLoadAB());
    }

    public void OnClick_StartGame()
    {
        print("scenename is " + this.icon_GameSceneName);

        LoadingGameManager.ab_URL = this.icon_ABURL;
        LoadingGameManager.ab_Version = this.icon_ABVersion;
        LoadingGameManager.ab_scenename = this.icon_GameSceneName;

        Application.LoadLevel("LoadingGame");

        //StartCoroutine(LoadingAB());
    }

    public void OnFinish_DownLoadAB()
    {
        // 刪除下載球物件
        Object.DestroyObject(progressball.gameObject);
        progressball = null;

        int iconstate = this.GetIconState(false, 100, this.icon_ABURL, this.icon_ABVersion);
        print("OnFinish_DownLoadAB gameOrder is " + icon_gameorder + ", state is " + iconstate);
        
        // 重新設定icon、enable icon按鈕
        this.SetIConButton(iconstate);

    }

    private void SetIConSprite(string spritename)
    {
        UISprite uisprite = uibutton_icon.gameObject.GetComponentInChildren<UISprite>();
        
        // 換圖
        uisprite.spriteName = spritename;
    }

    // 0:等級太低不能玩; 1:未下載; 2:已下載; 3:Coming soon; 4:下載中
    private int GetIconState(bool comingsoon, int userlevel, string ABUrl,int version)
    {
        if (comingsoon)
            return 3;
        else if (userlevel < this.icon_LevelLimit)
            return 0;

        if (CheckDownloaded(ABUrl, version))
            return 2;
        else
            return 1;
    }

    private void SetIConButton(int iconstate)
    {
        UIPlayTween uiplaytween = uibutton_icon.gameObject.GetComponent<UIPlayTween>();
        UISprite uisprite = uibutton_icon.gameObject.GetComponentInChildren<UISprite>();
        
        if (iconstate == 0)
        {
            uiplaytween.enabled = false;
            uibutton_icon.enabled = false;
            uisprite.color = new Color(100.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 1.0f);
        }
        else if (iconstate == 1)
        {
            uiplaytween.enabled = false;
            uibutton_icon.enabled = false;
            uisprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }            
        else if (iconstate == 2)
        {
            uiplaytween.enabled = true;
            uibutton_icon.enabled = true;
            uisprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (iconstate == 3)
        {
            uiplaytween.enabled = false;
            uibutton_icon.enabled = false;
        }
    }

    private void SetDownloadSprite(int iconstate)
    {
        if (iconstate == 1)
            uibutton_download.gameObject.SetActive(true);
        else
            uibutton_download.gameObject.SetActive(false);
    }

    // 有無下載 AB 存放在Caching了
    private bool CheckDownloaded(string aburl,int version)
    {
        //return Caching.IsVersionCached(aburl, version);
        return ABCaching.IsVersionCached(aburl, version);
    }

    public void SetLevelLimit(int userlevel)
    {
        if (userlevel >= icon_LevelLimit)
            uilabel_levellimit.gameObject.SetActive(false);
        else
        {
            uilabel_levellimit.gameObject.SetActive(true);
            uilabel_levellimit.text = "Level " + icon_LevelLimit.ToString();
        }
    }

    IEnumerator DownLoadAB()
    {

        if(ABCaching.IsVersionCached(this.icon_ABURL,this.icon_ABVersion))
        {
            Debug.LogError("found same asset bundle.");
        }
        else
        {
            using (www_loadAB = new WWW(this.icon_ABURL))
            {

                this.SW_LoadingAB = true;

                yield return www_loadAB;

                if (www_loadAB.error != null)
                {
                    Debug.LogError("DownLoadAB had an error : " + www_loadAB.error);
                }
                else
                {
                    ABCaching.Save(www_loadAB.bytes, this.icon_ABURL, this.icon_ABVersion);
                    www_loadAB.assetBundle.Unload(false);
                }
            }
            Debug.Log("Order " + icon_gameorder + " 載完 Game AB ! ");
            www_loadAB = null;
        }
        /*
        using (www_loadAB = WWW.LoadFromCacheOrDownload(url, this.icon_ABVersion))
        {
            this.SW_LoadingAB = true;

            yield return www_loadAB;

            if(www_loadAB.error != null)
            {
                Debug.LogError("DownLoadAB had an error : " + www_loadAB.error);
            }
            else
            {
                www_loadAB.assetBundle.Unload(false);
            }
        }
        Debug.Log("Order " + icon_gameorder +" 載完 Game AB ! ");
        www_loadAB = null;
        */
    }

}
