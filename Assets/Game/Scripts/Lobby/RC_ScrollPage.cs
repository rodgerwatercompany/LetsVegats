using UnityEngine;
using System.Collections;

public class RC_ScrollPage : MonoBehaviour
{
    public int NextPos_x;

    public float Movespeed;

    public int Distance;

    private bool ismoving;

    private bool isright;

    public RC_ScrollIcon[] icons;

    void Update()
    {
        if (ismoving)
        {
            if (isright)
            {
                float nextpos_x = gameObject.transform.localPosition.x + Movespeed * Time.deltaTime;

                if (nextpos_x >= (float)NextPos_x)
                {
                    gameObject.transform.localPosition = new Vector3((float)NextPos_x, 0.0f, 0.0f);
                    isright = false;
                }
                else
                {
                    gameObject.transform.localPosition = new Vector3(nextpos_x, 0.0f, 0.0f);
                }
            }
            else
            {
                float nextpos_x = gameObject.transform.localPosition.x - Movespeed * Time.deltaTime;

                if (nextpos_x <= (float)NextPos_x)
                {
                    gameObject.transform.localPosition = new Vector3((float)NextPos_x, 0.0f, 0.0f);
                    isright = false;
                }
                else
                {
                    gameObject.transform.localPosition = new Vector3(nextpos_x, 0.0f, 0.0f);
                }

            }
        }

    }

    public void Init(int nowposx, int movespeed, int distance)
    {
        NextPos_x = nowposx;
        //gameObject.transform.localPosition = new Vector3((float)nowposx, 0.0f, 0.0f);
        Movespeed = movespeed;
        Distance = distance;

        ismoving = false;
    }

    public void StartMoveNext(bool dir_right)
    {
        // set dir.
        isright = dir_right;

        // calculate next pos.
        if (dir_right)
        {
            NextPos_x = NextPos_x + Distance;
            ismoving = true;
        }
        else
        {
            NextPos_x = NextPos_x - Distance;
            ismoving = true;
        }

    }


    // idx start counting at 0
    public void InitIcon(int gameorder,
        int idx,
        string name_sp,
        int levellimit,
        string gamescenename,
        bool comingsoon,
        int userlevel,
        string ABurl,
        int ABversion)
    {
        icons[idx].Init(gameorder:gameorder,
            name_sp:name_sp,
            levellimit:levellimit,
            gamescenename:gamescenename,
            comingsoon:comingsoon,
            userlevel:userlevel,
            ABUrl:ABurl,
            ABversion:ABversion);
    }
}
