using LitJson;
using System.Collections;
using UnityEngine;

public class LobbyManager : MonoBehaviour 
{

    public RC_ScrollManager scrollManager;

    public UIPanel MessagePanel;

    // For Delete Game
    public delegate void FinishDelete();

    FinishDelete finishDelete;
    private string game_url;
    private int game_version;

    void Awake()
    {
        if (ABManager.assetbundle_Lobby != null)
            ABManager.assetbundle_Lobby.Unload(false);
    }

	// Use this for initialization
	void Start () {

        MessagePanel.alpha = 0.0f;

        this.Init();
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

    public void OpenMessagePanel(string url, int version, FinishDelete finishdelete)
    {
        game_url = url;
        game_version = version;
        finishDelete = finishdelete;

        MessagePanel.alpha = 1.0f;
    }

    public void OnClick_DeleteGame()
    {
        MessagePanel.alpha = 0.0f;

        // 刪除並重新檢查 ICon 狀態
        ABCaching.Delete(game_url, game_version);

        finishDelete();
    }

    public void OnClick_CloseMessagePanel()
    {
        MessagePanel.alpha = 0.0f;

    }

    void OnApplicationFocus()
    {
        //Debug.Log("OnApplicationFocus  !");
        //Application.LoadLevel("Loading");
    }
}
