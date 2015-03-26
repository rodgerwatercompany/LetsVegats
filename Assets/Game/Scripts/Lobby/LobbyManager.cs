using LitJson;
using System.Collections;
using UnityEngine;

public class LobbyManager : MonoBehaviour 
{

    public RC_ScrollManager scrollManager;

    void Awake()
    {

        if (ABManager.assetbundle_Lobby != null)
            ABManager.assetbundle_Lobby.Unload(false);
    }

	// Use this for initialization
	void Start () {

        this.Init();
	}	

	// Update is called once per frame
	void Update () {
	
	}

    void Init()
    {

        JsonData jd_UserInfo = JsonManager.GetJD("UserInfo",new string[] { "UserInfo" });
        JsonData jd_GameList = JsonManager.GetJD("GameListInfo", new string[] { "GameList" });

        int userlevel = (int)jd_UserInfo["GameLevel"];

        Debug.Log("jd_GameList.Count is " + jd_GameList.Count);
        for(int i = 0 ; i < jd_GameList.Count ; i++)
        {

            int order               = (int)jd_GameList[i]["ORDER"];
            string ABurl            = jd_GameList[i]["ABURL"].ToString();
            int ABVersion           = (int)jd_GameList[i]["ABVersion"];
            string GameSceneName    = jd_GameList[i]["GameSceneName"].ToString();
            bool comingsoon         = (bool)jd_GameList[i]["ComingSoon"];
            int limit               = (int)jd_GameList[i]["LIMIT"];
            string spritename       = jd_GameList[i]["SPRITENAME"].ToString();

            scrollManager.InitIcon(gameorder:order,
                order_icon:order,
                name_sp:spritename,
                levellimit:limit,
                gamescenename: GameSceneName,
                comingsoon: comingsoon,
                userlevel: userlevel,
                ABUrl: ABurl,
                ABversion: ABVersion);
        }
    }

    void OnApplicationFocus()
    {
        //Debug.Log("OnApplicationFocus  !");
        //Application.LoadLevel("Loading");
    }
}
