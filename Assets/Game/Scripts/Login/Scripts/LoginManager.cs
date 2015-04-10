using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using LitJson;

public class LoginManager : MonoBehaviour
{

    string[] esball_ips = { "bm.ago545q6e5.com" ,
                            "bm.efr465dwd789.com",
                            "bm.kkmfdfv.com",
                            "bm.gjje18644cc.com",
                            "bm.tjefjjvmcw.com",
                            "bm.bo558z7cv5.com",
                            "bm.acga778qmz579.com",
                            "bm.ddhqywa.com",
                            "bm.zooe19734qq.com",
                            "bm.hgznfgqkgie.com"
                            };

    Dictionary<string, string> dic_errortable_tw;

    public UIInput uiinput_account;
    public UIInput uiinput_password;

    public GameObject prefab_msg;

    void Awake()
    {

        // 禁止休眠
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // 建立錯誤訊息表
        dic_errortable_tw = new Dictionary<string, string>();

        dic_errortable_tw.Add("90002", "會員帳號或密碼錯誤");
        dic_errortable_tw.Add("90004", "會員凍結");
        dic_errortable_tw.Add("90005", "會員停用");
        dic_errortable_tw.Add("90006", "30秒重覆登入");
        dic_errortable_tw.Add("90007", "會員停權");
        dic_errortable_tw.Add("90015", "廳主DomainCode不存在");
        //dic_errortable_tw.Add("90018", "");
        dic_errortable_tw.Add("44001", "參數未帶齊");
        dic_errortable_tw.Add("22000", "使用者未登入");
        dic_errortable_tw.Add("22001", "使用者登出");
    }


    public void OnClick_UserLogin()
    {

        string str_acc = uiinput_account.value;
        string str_pw = uiinput_password.value;

        string[] infos = str_acc.Split('@');
        int rand = Random.Range(0, 9);

        // 檢查帳號格式
        if (infos.Length == 2 && str_pw.Length != 0)
        {

            string url = "http://" + esball_ips[rand] + "/amfphp/json.php/Member.getDomainList/" + infos[1];

            StartCoroutine(GetDomain(url));
        }
        else
            print("錯誤的格式");
    }

    IEnumerator GetDomain(string url)
    {

        print("GetDomain");
        using (WWW www = new WWW(url))
        {

            yield return www;

            if (www.error != null)
                print("getdomain.error is " + www.error);
            else
            {
                print(www.text);

                if (www.text != "Durian ERROR!")
                {
                    JsonData jd = JsonMapper.ToObject(www.text);

                    ICollection i_keys = ((IDictionary)(jd["domain"])).Keys;
                    string[] strs = new string[2];
                    i_keys.CopyTo(strs, 0);

                    string domain = jd["domain"][strs[0]][0].ToString();

                    string url_esball = "https://" + domain + "/amfphp/json.php/Member.getServerIp";

                    StartCoroutine(GetIP(url_esball));
                }
                else
                    print("Server 斷線");
            }
        }
    }

    IEnumerator GetIP(string url)
    {
        print("GetIP");
        using (WWW www = new WWW(url))
        {

            yield return www;

            if (www.error != null)
                print("getdomain.error is " + www.error);
            else
            {

                print(www.text);

                JsonData jd = JsonMapper.ToObject(www.text);
                string ip_esball = jd["data"]["ip"].ToString();

                RtmpC2S.hallid = (jd["data"]["HallID"]).ToString();

                string str_acc = uiinput_account.value;
                string user_pw = uiinput_password.value;

                string[] infos = str_acc.Split('@');

                string user_acc = infos[0];
                string domaincode = infos[1];

                string url_getsid = "http://bm.esballgame.com" +
                "/app/WebService/view/display.php/MobileLogin?username=" + user_acc +
                "&password=" + user_pw +
                "&domaincode=" + domaincode +
                "&ip=" + ip_esball +
                "&platform=iPhone";

                StartCoroutine(GetSid(url_getsid, ip_esball));
            }
        }
    }

    IEnumerator GetSid(string url, string ip)
    {

        print("GetSid");
        using (WWW www = new WWW(url))
        {

            yield return www;

            if (www.error != null)
                print("GetSid.error is " + www.error);
            else
            {
                print(www.text);

                JsonData jd = JsonMapper.ToObject(www.text);

                if ((bool)jd["result"])
                {

                    string sid = "";
                    sid = jd["data"]["session_token"].ToString();

                    RtmpC2S.userid = (jd["data"]["UserID"]).ToString();

                    if (sid != "")
                    {

                        print("sid is " + sid);

                        RtmpC2S.sid = sid;
                        RtmpC2S.ip = ip;
                        Application.LoadLevel("Loading");
                    }

                }
                else
                {
                    ShowError(jd);
                }
            }
        }
    }

    void ShowError(JsonData jd)
    {

        string str = jd["data"]["Code"] + " Message is " + jd["data"]["Message"];
        
        string str_error = "";
        string key = (jd["data"]["Code"]).ToString();

        dic_errortable_tw.TryGetValue(key , out str_error);

        GameObject ga_coverpanel = GameObject.Find("CoverPanel");
        GameObject ga = Instantiate(
            prefab_msg,
            new Vector3(0.0f, 0.0f, 0.0f),
            Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;

        ga.transform.parent = ga_coverpanel.transform;
        GF_Window window = ga.GetComponent("GF_Window") as GF_Window;

        if (str_error == "")
            window.SetContext(str);
        else
            window.SetContext(str_error);
    }
}