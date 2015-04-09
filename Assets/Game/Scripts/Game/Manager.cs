using UnityEngine;
using System.Collections;

using LitJson;

public class Manager : MonoBehaviour
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


    void Awake()
    {

        if (ABManager.assetbundle_Game != null)
            ABManager.assetbundle_Game.Unload(false);

        // 禁止休眠
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    /*
    // 呼叫連線API
    private void Connect(string ip)
    {
        print("Connect");
        RtmpC2S.Connect(ip);
    }*/
}