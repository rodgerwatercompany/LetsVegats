using UnityEngine;
using System.Collections;

public class SlotMachine : MonoBehaviour {


    public LuaManager_new luaMgr;

    public TileLine[] tileLines;
    public float SlotSpeed_max;

    private float[] fspeeds;

    private bool bBreak;

    private string[] tilesprites;


    public string Name_Function_FinishStopSpin;

    // Use this for initialization
    void Start()
    {

        foreach (TileLine tileline in tileLines)
            tileline.SetSpeed(this.SlotSpeed_max);

        bBreak = false;
        fspeeds = new float[5] { 0, 0 , 0 , 0  , 0 };
    }
	
	// Update is called once per frame
	void Update () {

	    if(bBreak)
        {

            int idx = GetNowIdx();
            if (idx != -1)
            {

                fspeeds[idx] -= (1000 * Time.deltaTime);

                if (fspeeds[idx] <= 600.0f)
                {
                    fspeeds[idx] = 600.0f;
                    tileLines[idx].SetSprites(GetTileSpriteInfo(idx));
                    tileLines[idx].StopRun();
                }

                tileLines[idx].SetSpeed(fspeeds[idx]);
            }
            else
            {
                bBreak = false;

                // 通知滾輪全部停止轉動
                CallLua_FinisStopSpin();
            }
        }
	}

    private void CallLua_FinisStopSpin()
    {
        luaMgr.CallLuaFuction(Name_Function_FinishStopSpin);
    }

    public void OnClick_StartRun()
    {

        for (int i = 0; i < 5; i++)
        {
            fspeeds[i] = this.SlotSpeed_max;
            tileLines[i].SetSpeed(this.SlotSpeed_max);
        }

        foreach (TileLine tileline in tileLines)
            tileline.StartRun();
    }

    public void OnClick_StartStop()
    {

        bBreak = true;
        /*
        foreach (TileLine tileline in tileLines)
            tileline.StopRun();
         */
    }

    public void SetTileSpriteInfo(string[] sprites)
    {

        tilesprites = sprites;
        /*
        foreach (string name in tilesprites)
            print("id is " + name);
        */
    }

    // 灰階
    public void GreyTileObjects()
    {

    }
    // 恢復顏色
    public void RecoverAllTileObject()
    {

    }

    private string[] GetTileSpriteInfo(int idx)
    {

        int len = tilesprites.Length / tileLines.Length;

        int start = (idx * len);

        string[] ret = new string[len];

        for (int i = 0, j = start; j < start + len; i++, j++)
        {
            ret[i] = tilesprites[j];
            //print("idx : " + idx + " tilesprites[" + j + "] : " + tilesprites[j]);
        }

        return ret;
    }

    private int GetNowIdx()
    {

        for(int i = 0; i < 5; i++)
        {
            if (fspeeds[i] > 600.0f)
                return i;            
        }
        return -1;
    }
}
