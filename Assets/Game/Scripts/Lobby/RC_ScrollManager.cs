using UnityEngine;
using System.Collections;

public class RC_ScrollManager : MonoBehaviour 
{

    public int distance;

    public int Pagesize;

    public int MoveSpeed;

    public GameObject Res_Page;

    private RC_ScrollPage[] pages;

    private int NowPageID;

    
    void Start()
    {

        NowPageID = 0;

        pages = new RC_ScrollPage[Pagesize];

        for (int i = 0; i < Pagesize; i++)
        {
            float offset_x = i * distance;

            GameObject gaobj = Instantiate(Res_Page,
                                            new Vector3(0.0f, 0.0f, 0.0f),
                                            Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)))
                                            as GameObject;

            gaobj.transform.parent = gameObject.transform;
            gaobj.transform.localPosition = new Vector3(offset_x, 0.0f, 0.0f);
            gaobj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            pages[i] = gaobj.GetComponent<RC_ScrollPage>();

            pages[i].Init((int)offset_x, MoveSpeed, distance);
        }
    }

    public void MoveRight()
    {
        if (NowPageID > 0)
        {
            foreach (RC_ScrollPage page in pages)
            {
                page.StartMoveNext(true);
            }

            NowPageID--;
        }
    }

    public void MoveLeft()
    {
        if (NowPageID < 7)
        {
            foreach (RC_ScrollPage page in pages)
            {
                page.StartMoveNext(false);
            }

            NowPageID++;
        }
    }

    // id start counting at 0
    public void InitIcon(int gameorder,
        int order_icon,
        string name_sp,
        int levellimit,
        string gamescenename,
        bool comingsoon,
        int userlevel,
        string ABUrl,
        int ABversion)
    {
        int idx_page = order_icon / 6;
        int idx_icon = order_icon % 6;

        pages[idx_page].InitIcon(gameorder: gameorder,
            idx: idx_icon,
            name_sp: name_sp,
            levellimit: levellimit,
            gamescenename:gamescenename,
            comingsoon:comingsoon,
            userlevel:userlevel,
            ABurl:ABUrl,
            ABversion:ABversion);

    }

}
